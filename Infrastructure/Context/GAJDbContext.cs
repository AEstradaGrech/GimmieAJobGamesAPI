using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.EntitiesCF;
using Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class GAJDbContext : DbContext, IUnitOfWork
    {
        public GAJDbContext(DbContextOptions<GAJDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameEntityConfiguration());
            builder.ApplyConfiguration(new StudioEntityConfiguration());
            builder.ApplyConfiguration(new GamePromotionEntityTypeConfiguration());
            builder.ApplyConfiguration(new PromotionEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await SaveChangesAsync() >= 1;
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<GamePromotion> GamePromotions { get; set; }
        public DbSet<GameStudio> GameStudio { get; set; }
    }
}
