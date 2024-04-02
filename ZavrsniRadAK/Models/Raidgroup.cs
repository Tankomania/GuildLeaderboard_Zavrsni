using System;
using System.Collections.Generic;

namespace ZavrsniRadAK.Models
{
    public partial class Raidgroup
    {
        public Raidgroup()
        {
            Progresses = new HashSet<Progress>();
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string Groupname { get; set; } = null!;
        public string Difficulty { get; set; } = null!;

        public virtual ICollection<Progress> Progresses { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
