using System;
using System.Collections.Generic;

namespace ZavrsniRadAK.Models
{
    public partial class Member
    {
        public Member()
        {
            Raidgroups = new HashSet<Raidgroup>();
        }

        public int Id { get; set; }
        public string? Memname { get; set; }
        public string? Memclass { get; set; }
        public string? Race { get; set; }
        public int? Charlevel { get; set; }
        public string? Realm { get; set; }
        public int? GuildId { get; set; }
        public virtual ICollection<Raidgroup> Raidgroups { get; set; }
    }
}
