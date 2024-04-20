
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ZavrsniRadAK.Data;

namespace ZavrsniRadAK.Controllers;

[ApiController]
public class RaidInfoController : ControllerBase
{
    private readonly GuildLeaderboard_ZavrsniContext _context;

    public RaidInfoController(GuildLeaderboard_ZavrsniContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("api/[controller]/{guildId}")]
    public IActionResult GetRaidInfo(int guildId)
    {
        var raidInfoList = (from r in _context.Raids
                            join p in _context.Progresses on r.RaidgroupClear equals p.Raidgroup
                            join rp in _context.Raidgroups on r.RaidgroupClear equals rp.Id
                            from m in rp.Members
                            where m.GuildId == guildId
                            select new GuildRaidInfo
                            {
                                RaidName = r.Raidname,
                                Difficulty = rp.Difficulty,
                                ClearDate = (DateTime)p.Cleardate
                            }).Distinct().ToList();

        return Ok(raidInfoList);
        }
        
    }

public class GuildRaidInfo
{
    public string RaidName { get; set; }
    public string Difficulty { get; set; }
    public DateTime ClearDate { get; set; }
}

