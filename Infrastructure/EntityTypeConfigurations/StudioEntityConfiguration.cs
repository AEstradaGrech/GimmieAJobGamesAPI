using System;
using Domain.EntitiesCF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations
{
    public class StudioEntityConfiguration : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.StudioName)
                   .HasColumnName("Name")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.HasIndex(s => s.StudioName)
                   .IsUnique();
           
        }
    }
}
