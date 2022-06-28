using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public interface IDbService
    {
        Task<IEnumerable<SomeKindOfTeams>> GetTeam(int id);
    }
}
