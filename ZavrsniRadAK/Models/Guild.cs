using System;
using System.Collections.Generic;

namespace ZavrsniRadAK.Models
{
    public partial class Guild
    {

        public int Id { get; set; }
        public string Gname { get; set; } = null!;
        public string Realm { get; set; } = null!;

    }
}
