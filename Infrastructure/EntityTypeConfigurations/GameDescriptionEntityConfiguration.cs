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
                   .HasColumnType("MEDIUMTEXT")
                   .IsRequired();                   

            builder.Property(e => e.GameTitle)
                   .IsRequired();

            builder.HasIndex(e => e.GameTitle)
                   .IsUnique();

            builder.HasOne(e => e.Game)
                   .WithOne(g => g.GameDescription)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
