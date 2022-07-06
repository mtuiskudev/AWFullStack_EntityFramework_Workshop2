using System;
using AWFullStack_EntityFramework_Workshop2.Models;

namespace AWFullStack_EntityFramework_Workshop2
{
    class Program
    {
        static void Main(string[] args)
        {
            Pelaaja pertsa = new Pelaaja();
            pertsa.PelaajaNimi = "Pertsa";
            pertsa.PelaajaLuokka = "Warlock";
            pertsa.PelaajaTaso = 1350;

            using (var db = new Testi_dbContext())
            {
                
                
                Varuste hc = new Varuste();
                hc.VarusteNimi = "Malfeasance";
                hc.VarusteTyyppi = "Handcannon";
                hc.VarusteTaso = 1500;
                hc.OmistajaNavigation = pertsa;

                db.Add(hc);


                db.Add(pertsa);

                db.SaveChanges();
            }
        }
    }
}
