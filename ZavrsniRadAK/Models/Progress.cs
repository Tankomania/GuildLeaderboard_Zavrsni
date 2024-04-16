using System;
using System.Collections.Generic;

namespace ZavrsniRadAK.Models
{
    public partial class Progress
    {
        public Progress()
        {
            Raids = new HashSet<Raid>();
        }

        public int Id { get; set; }
        public int? Raidgroup { get; set; }
        public DateTime? Cleardate { get; set; }

        public virtual Raidgroup? RaidgroupNavigation { get; set; }
        public virtual ICollection<Raid> Raids { get; set; }
    }
}
