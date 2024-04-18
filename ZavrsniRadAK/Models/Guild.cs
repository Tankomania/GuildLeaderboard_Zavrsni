using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZavrsniRadAK.Models
{
    public partial class Guild
    {
        public int Id { get; set; }
        public string Gname { get; set; } = null!;
        public string Realm { get; set; } = null!;

    }
}
