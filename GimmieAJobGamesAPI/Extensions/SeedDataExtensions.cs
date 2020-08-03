using System;
using System.Collections.Generic;
using System.Linq;
using Domain.EntitiesCF;
using Domain.Enums;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GimmieAJobGamesAPI.Extensions
{
    public static class SeedDataExtensions
    {
        public static GAJDbContext SeedData(this GAJDbContext context)
        {
            return context.SeedStudios()
                          .SeedGames()
                          .SeedGameStudios()
                          .SeedPromotions()
                          .SeedGamePromotions()
                          .SeedGameDescriptions();
        }

        private static GAJDbContext SeedGameStudios(this GAJDbContext context)
        {
            var gameStudios = GetGameStudios(context);
                        
            if (!context.GameStudio.Any())
                context.AddRange(gameStudios);

            context.SaveChanges();

            return context;
        }

        private static GAJDbContext SeedGames(this GAJDbContext context)
        {
            var games = GetGames();

            if (!context.Games.Any())
            {
                context.Games.AddRange(games);

                context.SaveChanges();

                return context;
            }               

            if(context.Games.Count() < games.Count)
            {
                games.ForEach(g =>
                {
                    if (!context.Games.Any(x => x.Title == g.Title))
                        context.Games.Add(g);
                });
            }

            context.SaveChanges();

            return context;
        }

        private static GAJDbContext SeedGamePromotions(this GAJDbContext context)
        {
            var data = GetGamePromotions(context);

            if (!context.GamePromotions.Any())
            {
                context.GamePromotions.AddRange(data);

                context.SaveChanges();

                return context;
            }                

            if(context.GamePromotions.Count() < data.Count)
            {
                foreach(var item in context.GamePromotions)
                {
                    context.GamePromotions.Remove(item);
                }

                context.SaveChanges();

                context.GamePromotions.AddRange(data);                
            }

            context.SaveChanges();

            return context;
        }

        private static GAJDbContext SeedPromotions(this GAJDbContext context)
        {
            var promos = GetPromotions();

            if (!context.Promotions.Any())
            {
                context.AddRange(promos);

                context.SaveChanges();

                return context;
            }                

            if(context.Promotions.Count() < promos.Count)
            {
                promos.ForEach(x =>
                {
                    if (!context.Promotions.Any(p => p.Description == x.Description))
                        context.Promotions.Add(x);
                });
            }

            context.SaveChanges();

            return context;
        }

        private static GAJDbContext SeedStudios(this GAJDbContext context)
        {
            var studios = GetStudios();

            if (!context.Studios.Any())
            {
                context.Studios.AddRange(studios);

                context.SaveChanges();

                return context;
            }
                

            if(context.Studios.Count() < studios.Count)
            {
                studios.ForEach(s =>
                {
                    if (!context.Studios.Any(x => x.StudioName == s.StudioName))
                        context.Studios.Add(s);
                });
            }

            context.SaveChanges();

            return context;
        }

        private static GAJDbContext SeedGameDescriptions(this GAJDbContext context)
        {
            if (context.GameDescriptions.Count() <= 0)
            {
                var games = context.Games.AsEnumerable();

                if (games.Count() > 0)
                {
                    foreach (Game game in games)
                    {
                        GameDescription desc = new GameDescription { GameId = game.Id, GameTitle = game.Title, Description = GetTestGameDescription() };

                        context.GameDescriptions.Add(desc);
                    }

                    context.SaveChanges();
                }
            }

            return context;
        }

        private static string GetTestGameDescription()
        {            
            return @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris condimentum leo in sem pulvinar scelerisque. Duis quis scelerisque sem, quis fringilla velit.
                     Suspendisse eget porttitor velit, et tincidunt arcu. Fusce finibus enim sit amet odio dignissim, quis consequat tortor placerat. Duis et sagittis ligula.
                     Cras diam risus, dictum nec tortor eget, luctus semper mauris. Nunc ac rhoncus velit. Quisque feugiat magna a ex suscipit, ut tincidunt sapien venenatis.
                     Aliquam lacinia blandit quam id porttitor. Maecenas volutpat lacinia lectus id venenatis. Morbi semper mi id imperdiet posuere.";
        }

        private static List<Promotion> GetPromotions()
        {
            return new List<Promotion>
            {
                new Promotion
                {
                    Description = "25% Off",
                    Discount = 25
                },
                new Promotion
                {
                    Description = "50% Off",
                    Discount = 50
                },
                new Promotion
                {
                    Description = "75% Off",
                    Discount = 75
                },
                new Promotion
                {
                    Description = "Free",
                    Discount = 100
                },
                new Promotion
                {
                    Description = "2X1",
                    Discount = 100
                }
            };
        }

        private static List<Studio> GetStudios()
        {
            return new List<Studio>
            {
                new Studio
                {
                    StudioName = "Electronic Arts",
                    Established = new DateTime(1982,05,27)
                },
                new Studio
                {
                    StudioName = "Bethesda",
                    Established = new DateTime(1986,06,28)
                },
                new Studio
                {
                    StudioName = "Activision",
                    Established = new DateTime(1978,10,01)
                },
                new Studio
                {
                    StudioName = "2KGames",
                    Established = new DateTime(2005,01,25)
                },
                new Studio
                {
                    StudioName = "CD Projekt",
                    Established = new DateTime(1994,05,01)
                },
                new Studio
                {
                    StudioName = "IdSoftware",
                    Established = new DateTime(1991,02,01)
                },
                new Studio
                {
                    StudioName = "Konami",
                    Established = new DateTime(1969,03,21)
                },
                new Studio
                {
                    StudioName = "Arkane Studios",
                    Established = new DateTime(1999,10,12)
                },
                new Studio
                {
                    StudioName = "Avalanche Studios",
                    Established = new DateTime(2003,03,21)
                },
                new Studio
                {
                    StudioName = "GearBox",
                    Established = new DateTime(1999,02,16)
                },
                new Studio
                {
                    StudioName = "4A Games",
                    Established = new DateTime(2006,01,01)
                },
                new Studio
                {
                    StudioName = "Ubisoft",
                    Established = new DateTime(1986,03,28)
                },
                new Studio
                {
                    StudioName = "Cloud Imperium Games",
                    Established = new DateTime(2012,04,01)
                },
                 new Studio
                {
                    StudioName = "MachineGames",
                    Established = new DateTime(2009,05,14)
                },
                new Studio
                {
                    StudioName = "Naughty Dog",
                    Established = new DateTime(1984,01,01)
                },
                new Studio
                {
                    StudioName = "Sony Computer Ent.",
                    Established = new DateTime(1993,11,16)
                },
                new Studio
                {
                    StudioName = "Deep Silver",
                    Established = new DateTime(2002,01,01)
                }

            };
        }

        private static List<GamePromotion> GetGamePromotions(GAJDbContext context)
        {
            return new List<GamePromotion>
            {
                new GamePromotion
                {
                    GameId = context.Games.First(g => g.Title == "Battlefield 1").Id,
                    StudioId = null,
                    AccountType = AccountTypes.Regular,
                    Promotion = context.Promotions.First(p => p.Discount == 25),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1)
                },
                new GamePromotion
                {
                    GameId = context.Games.First(g => g.Title == "Rainbow Six Siege").Id,
                    StudioId = null,
                    AccountType = AccountTypes.Regular,
                    Promotion = context.Promotions.First(p => p.Discount == 50),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1)
                },
                new GamePromotion
                {
                    GameId = context.Games.First(g => g.Title == "Dead Island").Id,
                    StudioId = null,
                    AccountType = null,
                    Promotion = context.Promotions.First(p => p.Description == "Free"),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1)
                },
                new GamePromotion
                {
                    GameId = null,
                    StudioId = context.Studios.SingleOrDefault(s => s.StudioName == "Bethesda").Id,
                    AccountType = null,
                    Promotion = context.Promotions.First(p => p.Discount == 25),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1)
                },
                new GamePromotion
                {
                    GameId = null,
                    StudioId = context.Studios.SingleOrDefault(s => s.StudioName == "Bethesda").Id,
                    AccountType = AccountTypes.Silver,
                    Promotion = context.Promotions.First(p => p.Discount == 75),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1)
                },
                new GamePromotion
                {
                    GameId = null,
                    StudioId = context.Studios.SingleOrDefault(s => s.StudioName == "Konami").Id,
                    AccountType = AccountTypes.Bronze,
                    Promotion = context.Promotions.First(p => p.Description == "2X1"),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1)
                },
                new GamePromotion
                {
                    GameId = context.Games.First(g => g.Title == "Borderlands 3").Id,
                    StudioId = null,
                    AccountType = AccountTypes.Gold,
                    Promotion = context.Promotions.First(p => p.Description == "Free"),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1)
                }
            };
        }

        private static List<Game> GetGames()
        {
            return new List<Game>
            {
                new Game
                {
                    Title = "Battlefield 1",
                    Genre = "Action/FPS",
                    PEGI = PEGI.PEGI_18,
                    Players = 64,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2017,03,28),
                    Price = 34.95m
                },
                new Game
                {
                    Title = "Battlefront II",
                    Genre = "Action/FPS",
                    PEGI = PEGI.PEGI_16,
                    Players = 40,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2017,11,17),
                    Price = 26.25m
                },
                new Game
                {
                    Title = "Fallout 3",
                    Genre = "Action/RPG",
                    PEGI = PEGI.PEGI_18,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2008,10,30),
                    Price = 19.95m
                },
                new Game
                {
                    Title = "Fallout 4",
                    Genre = "Action/RPG",
                    PEGI = PEGI.PEGI_18,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2015,11,10),
                    Price = 14.95m
                },
                new Game
                {
                    Title = "Wolfenstein New Order",
                    Genre = "Action/FPS",
                    PEGI = PEGI.PEGI_18,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2014,05,20),
                    Price = 10.00m
                },
                new Game
                {
                    Title = "Call Of Duty Warzone",
                    Genre = "Action/FPS",
                    PEGI = PEGI.PEGI_18,
                    Players = 150,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2020,03,10),
                    Price = null
                },
                new Game
                {
                    Title = "Borderlands 3",
                    Genre = "Action/RPG",
                    PEGI = PEGI.PEGI_16,
                    Players = 4,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2019,09,13),
                    Price = 19.90m
                },
                new Game
                {
                    Title = "The Witcher 3",
                    Genre = "Action/RPG",
                    PEGI = PEGI.PEGI_16,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2015,05,19),
                    Price = 39.95m
                },
                new Game
                {
                    Title = "Cyberpunk 2077",
                    Genre = "Action/RPG",
                    PEGI = PEGI.PEGI_18,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2020,09,17),
                    Price = null
                },
                new Game
                {
                    Title = "RAGE",
                    Genre = "Action/FPS",
                    PEGI = PEGI.PEGI_18,
                    Players = 4,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2011,10,07),
                    Price = 4.95m
                },
                new Game
                {
                    Title = "RAGE 2",
                    Genre = "Action/FPS",
                    PEGI = PEGI.PEGI_18,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2019,05,19),
                    Price = 45.95m
                },
                new Game
                {
                    Title = "Metal Gear Solid 3",
                    Genre = "Action/Stealth",
                    PEGI = PEGI.PEGI_16,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2004,11,09),
                    Price = 4.95m
                },
                new Game
                {
                    Title = "Metal Gear Solid V",
                    Genre = "Action/Stealth",
                    PEGI = PEGI.PEGI_18,
                    Players = 16,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2015,09,05),
                    Price = 26.95m
                },
                new Game
                {
                    Title = "Mad Max",
                    Genre = "Adventure/Action",
                    PEGI = PEGI.PEGI_18,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2015,10,04),
                    Price = 19.90m
                },
                new Game
                {
                    Title = "Metro Redux",
                    Genre = "Survival/FPS",
                    PEGI = PEGI.PEGI_18,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2014,08,29),
                    Price = 12.90m
                },
                new Game
                {
                    Title = "Star Citizen",
                    Genre = "Action/FPS",
                    PEGI = PEGI.PEGI_16,
                    Players = 64,
                    IsOnline = true,
                    ReleaseDate = null,
                    Price = null
                },
                new Game
                {
                    Title = "Uncharted",
                    Genre = "Action/TPS",
                    PEGI = PEGI.PEGI_16,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2007,12,05),
                    Price = 19.90m
                },
                new Game
                {
                    Title = "Rainbow Six Siege",
                    Genre = "FPS",
                    PEGI = PEGI.PEGI_18,
                    Players = 10,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2015,12,01),
                    Price = 19.90m
                },
                new Game
                {
                    Title = "Dead Island",
                    Genre = "Survival/Horror",
                    PEGI = PEGI.PEGI_18,
                    Players = 4,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2011,09,09),
                    Price = 19.90m
                },
                new Game
                {
                    Title = "Farcry 3",
                    Genre = "FPS",
                    PEGI = PEGI.PEGI_18,
                    Players = 16,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2012,11,29),
                    Price = 19.99m
                },
                new Game
                {
                    Title = "Dishonored",
                    Genre = "Action/Stealth",
                    PEGI = PEGI.PEGI_18,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2012,10,12),
                    Price = 56.95m
                },
                 new Game
                {
                    Title = "Dishonored 2",
                    Genre = "Action/Stealth",
                    PEGI = PEGI.PEGI_18,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2016,11,11),
                    Price = 14.95m
                },
                  new Game
                {
                    Title = "Bioshock Infinite",
                    Genre = "Action/RPG",
                    PEGI = PEGI.PEGI_18,
                    Players = 1,
                    IsOnline = false,
                    ReleaseDate = new DateTime(2013,03,26),
                    Price = 26.95m
                },
            };
        }

        private static List<GameStudio> GetGameStudios(GAJDbContext context)
        {
            return new List<GameStudio>
            {
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Battlefield 1").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Electronic Arts").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Battlefront II").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Electronic Arts").Id
                },
                new GameStudio
                {
                   GameId = context.Games.FirstOrDefault(g => g.Title == "Fallout 3").Id,
                   StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Bethesda").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Fallout 4").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Bethesda").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Wolfenstein New Order").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Bethesda").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Wolfenstein New Order").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "MachineGames").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Call Of Duty Warzone").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Activision").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Borderlands 3").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "GearBox").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "The Witcher 3").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "CD Projekt").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Cyberpunk 2077").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "CD Projekt").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "RAGE").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "IdSoftware").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "RAGE 2").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "IdSoftware").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Metal Gear Solid 3").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Konami").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Metal Gear Solid V").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Konami").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Mad Max").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Avalanche Studios").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Metro Redux").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "4A Games").Id
                },
                 new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Metro Redux").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Deep Silver").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Star Citizen").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Cloud Imperium Games").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Uncharted").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Naughty Dog").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Uncharted").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Sony Computer Ent.").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Rainbow Six Siege").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Ubisoft").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Dead Island").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Deep Silver").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Dead Island").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Sony Computer Ent.").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Farcry 3").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Ubisoft").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Dishonored").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Arkane Studios").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Dishonored").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Bethesda").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Dishonored 2").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Arkane Studios").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Dishonored 2").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "Bethesda").Id
                },
                new GameStudio
                {
                    GameId = context.Games.FirstOrDefault(g => g.Title == "Bioshock Infinite").Id,
                    StudioId = context.Studios.FirstOrDefault(s => s.StudioName == "2KGames").Id
                }
            };
        }
    }
}
