using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMBack.Models;

namespace TMBack.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(u => u.UserId); 
        }
    }
}
