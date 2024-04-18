using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZavrsniRadAK.Data;
using ZavrsniRadAK.Models;

namespace ZavrsniRadAK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null) { return BadRequest(); }

            var guildDeleteCheck = _context.Guilds.FirstOrDefault(td => td.Id == id);
            if (guildDeleteCheck == null) { return NotFound(); }

            var membersToUnassign = _context.Members.Where(m => m.GuildId == id);
            foreach (Member mem in membersToUnassign)
            {
                mem.GuildId = null;
                _context.Members.Update(mem);
            }
            _context.SaveChanges();
            var guildDelete = _context.Guilds.FirstOrDefault(td => td.Id == id);

            _context.Guilds.Remove(guildDelete);
            _context.SaveChanges();

            return Ok();
        }

        // POST: api/Guild
        [HttpPost]
        public IActionResult Post([FromBody] Guild guild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Guilds.Add(guild);
            _context.SaveChanges();

            return Ok();
        }

        // PUT: api/Guild/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Guild guild)
        {
            if (id != guild.Id)
            {
                return BadRequest();
            }

            _context.Entry(guild).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuildExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool GuildExists(int id)
        {
            return _context.Guilds.Any(e => e.Id == id);
        }
    }

}
