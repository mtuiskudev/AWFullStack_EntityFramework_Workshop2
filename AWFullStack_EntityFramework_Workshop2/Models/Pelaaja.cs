using System;
using System.Collections.Generic;

#nullable disable

namespace AWFullStack_EntityFramework_Workshop2.Models
{
    public partial class Pelaaja
    {
        public Pelaaja()
        {
            Varuste = new HashSet<Varuste>();
        }

        public int PelaajaId { get; set; }
        public string PelaajaNimi { get; set; }
        public int? PelaajaTaso { get; set; }
        public string PelaajaLuokka { get; set; }

        public virtual ICollection<Varuste> Varuste { get; set; }
    }
}
