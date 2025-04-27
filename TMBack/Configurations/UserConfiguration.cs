using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMBack.Models;

namespace TMBack.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.
                 HasMany(u => u.Tasks)
                .WithOne(t => t.User);

            builder
                .HasMany(u => u.RefreshTokens)
                .WithOne(r => r.User);
            
            builder.HasIndex(u => u.Email).IsUnique();

        }
    }
}
