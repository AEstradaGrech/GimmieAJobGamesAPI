using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;

namespace GimmieAJobGamesAPI.Services
{
    public interface ISqlQueryService
    {
        Task<IEnumerable<CatalogueGame>> GetStudioGames(string studioName);
    }
}
