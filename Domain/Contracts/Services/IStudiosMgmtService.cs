using System;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Contracts.Services
{
    public interface IStudiosMgmtService
    {
        Task<StudioDto> GetByName(string studioName);
    }
}
