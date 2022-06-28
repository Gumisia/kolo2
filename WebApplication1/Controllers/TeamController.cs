using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly IDbService _idbservice;
        public TeamController(IDbService idbservice)
        {
            _idbservice = idbservice;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await _idbservice.GetTeam(id);
            return Ok(team);
        }
    }
}
