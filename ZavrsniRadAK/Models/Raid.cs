using System;
using System.Collections.Generic;

namespace ZavrsniRadAK.Models
{
    public partial class Raid
    {
        public int Id { get; set; }
        public string Raidname { get; set; } = null!;
        public string Difficulty { get; set; } = null!;
        public int? RaidgroupClear { get; set; }

        public virtual Progress? RaidgroupClearNavigation { get; set; }
    }
}
