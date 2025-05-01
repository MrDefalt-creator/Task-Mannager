using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TMBack.Endpoints;
using TMBack.Extensions;
using TMBack.Infrastructure;
using TMBack.Interfaces.Auth;
using TMBack.Interfaces.Repositories;
using TMBack.Middleware;
using TMBack.Providers;
using TMBack.Repositories;
using TMBack.Services;

namespace TMBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;  
            var services = builder.Services;

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddApiAuthentication(builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>());

            // Настройка базы данных
            builder.Services.AddDbContext<TaskManagerDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(TaskManagerDbContext)));
            });

            services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Введите токен в формате: Bearer {your JWT token}"
                });
            
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            services.AddTransient<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserFromClaims, UserFromClaims>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<UsersService>();
            services.AddScoped<TaskService>();
            
            
            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API v1");
                });
            }
            
            
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors(policy => policy
                .WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
               MinimumSameSitePolicy = SameSiteMode.Lax,
               HttpOnly = HttpOnlyPolicy.Always,
               Secure = CookieSecurePolicy.None,
               
            });
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllers();   
            app.AddMappedEndpoints();
            app.Run();
        }
    }
}