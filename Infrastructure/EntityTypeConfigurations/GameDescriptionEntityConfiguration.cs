using System;
using Domain.EntitiesCF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations
{
    public class GameDescriptionEntityConfiguration : IEntityTypeConfiguration<GameDescription>
    {           
        public void Configure(EntityTypeBuilder<GameDescription> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                   .IsRequired();

            builder.Property(e => e.GameTitle)
                   .IsRequired();

            builder.HasIndex(e => new { e.GameTitle, e.Description })
                   .IsUnique();

            builder.HasOne(e => e.Game)
                   .WithOne(g => g.GameDescription)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
