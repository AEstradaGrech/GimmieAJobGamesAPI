using System;
using Domain.EntitiesCF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations
{
    public class GameEntityConfiguration : IEntityTypeConfiguration<Game>
    {      
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Title)
                   .HasMaxLength(30)
                   .IsRequired();
                        
        }
    }
}
