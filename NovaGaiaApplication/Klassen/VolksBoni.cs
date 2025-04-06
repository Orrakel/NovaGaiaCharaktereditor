using NovaGaiaCharaktereditor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaGaiaCharaktereditor.Klassen
{
    public class VolksBoni
    {
        public List<BoniEintrag> FesteBoni { get; set; } = new();
        public List<BoniEintrag> FreieBoni { get; set; } = new();
        public int MaxBoniauswahl { get; set; }
    }
}
