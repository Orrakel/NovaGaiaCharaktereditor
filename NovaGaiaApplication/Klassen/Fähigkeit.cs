using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaGaiaCharaktereditor.Klassen
{
    public class Fähigkeit
    {
        public string Name { get; set; }
        public string Effekt { get; set; }
        public int ChiKosten { get; set; }

        public override string ToString()
        {
            return $"{Name} (Chi: {ChiKosten})";
        }
    }
}
