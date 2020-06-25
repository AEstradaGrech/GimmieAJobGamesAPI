using System;
using Domain.EntitiesCF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations
{
    public class GameStudioEntityTypeConfiguration : IEntityTypeConfiguration<GameStudio>
    {
        public GameStudioEntityTypeConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<GameStudio> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Game)
                   .WithMany(g => g.GameStudios)
                   .HasForeignKey(e => e.GameId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Studio)
                   .WithMany(s => s.StudioGames)
                   .HasForeignKey(e => e.StudioId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
