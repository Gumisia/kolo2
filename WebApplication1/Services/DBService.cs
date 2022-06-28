using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public class DBService : IDbService
    {
        private readonly MainDbContext _mainDbContext;

        public DBService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<IEnumerable<SomeKindOfTeams>> GetTeam(int id)
        {
            return await _mainDbContext.Teams.Where(e => e.TeamId == id)
                        .Select(e => new SomeKindOfTeams
                        {
                            TeamId = e.TeamId,
                            TeamDescription = e.TeamDescription,
                            TeamName = e.TeamName,
                            /*Organizations = new Organization
                            {
   
                                OrganizationName = e.Organization.OrganizationName
                            },
                            Members = new Member { }*/


                        }).ToListAsync();
        }
    } 
}
