using System;
using System.Collections.Generic;
using System.Linq;
using Domain.EntitiesCF;
using Domain.Enums;
using Infrastructure.Context;

namespace GimmieAJobGamesAPI.Extensions
{
    public static class SeedDataExtensions
    {
        public static GAJDbContext SeedData(this GAJDbContext context)
        {
            return context.SeedGames()
                          .SeedStudios()
                          .SeedPromotions();
        }

        private static GAJDbContext SeedGames(this GAJDbContext context)
        {
            var data = GetGames();
            
            if (!context.Games.Any())
                context.AddRange(data);

            else if (context.Games.Count() < data.Count)
            {
                data.ForEach(x =>
                {
                    if (!context.Games.Any(g => g.Title == x.Title))
                        context.Games.Add(x);
                });
            }

            context.SaveChanges();

            return context;
        }

        private static GAJDbContext SeedStudios(this GAJDbContext context)
        {
            return context;
        }

        private static GAJDbContext SeedPromotions(this GAJDbContext context)
        {
            return context;
        }

        private static List<Game> GetGames()
        {
            return new List<Game>
            {
                new Game
                {
                    Title = "Battlefield 1",
                    Genre = "Action/FPS"
                    //PEGI = (int)PEGI.PEGI_18,

                }
            };
        }
    }
}
