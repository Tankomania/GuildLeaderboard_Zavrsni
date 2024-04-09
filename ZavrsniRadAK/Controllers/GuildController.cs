using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZavrsniRadAK.Data;

namespace ZavrsniRadAK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GuildController : ControllerBase
    {
        private GuildLeaderboard_ZavrsniContext _context;

        public GuildController(GuildLeaderboard_ZavrsniContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Guilds.ToList());
        }
    }
}
