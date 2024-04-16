using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZavrsniRadAK.Data;

namespace ZavrsniRadAK.Controllers
{
    
    
    [ApiController]

    public class MemberController : ControllerBase
    {
        private GuildLeaderboard_ZavrsniContext _context;

        public MemberController(GuildLeaderboard_ZavrsniContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            return Ok(_context.Members.ToList());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetSpecificMember(int id)
        {
            return Ok(_context.Members.Where(mem => mem.Id == id));
        }
        [Route("api/guildmembers/{guildId}")]
        [HttpGet]
        public IActionResult GetMembersByGuild(int guildId)
        {
            return Ok(_context.Members.Where(mem=>mem.GuildId == guildId).ToList());
        }
        
    }
}
