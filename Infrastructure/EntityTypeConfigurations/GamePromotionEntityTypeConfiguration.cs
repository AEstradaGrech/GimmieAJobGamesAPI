using System;
using Domain.EntitiesCF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations
{
    public class GamePromotionEntityTypeConfiguration : IEntityTypeConfiguration<GamePromotion>
    { 
        public void Configure(EntityTypeBuilder<GamePromotion> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Game)
                   .WithMany(g => g.GamePromotions)
                   .HasForeignKey(e => e.GameId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Studio)
                   .WithMany(s => s.GamePromotions)
                   .HasForeignKey(e => e.StudioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Promotion)
                   .WithMany(p => p.GamePromotion)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
