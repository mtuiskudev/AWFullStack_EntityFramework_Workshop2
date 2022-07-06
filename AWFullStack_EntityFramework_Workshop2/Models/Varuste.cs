using System;
using System.Collections.Generic;

#nullable disable

namespace AWFullStack_EntityFramework_Workshop2.Models
{
    public partial class Varuste
    {
        public int VarusteId { get; set; }
        public int? Omistaja { get; set; }
        public string VarusteNimi { get; set; }
        public string VarusteTyyppi { get; set; }
        public int? VarusteTaso { get; set; }

        public virtual Pelaaja OmistajaNavigation { get; set; }
    }
}
