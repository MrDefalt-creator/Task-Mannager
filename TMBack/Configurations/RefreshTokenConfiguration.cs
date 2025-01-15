using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMBack.Models;

namespace TMBack.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .HasOne(t => t.User)
                .WithMany(r => r.RefreshTokens)
                .HasForeignKey(r => r.UserId);
        }
    }
}
