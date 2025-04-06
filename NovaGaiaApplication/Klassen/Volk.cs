using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaGaiaCharaktereditor.Klassen
{
    public class Volk
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public Dictionary<string, int> Startattribute { get; set; }
        public List<string> Vorteile { get; set; } = new();
        public List<string> Nachteile { get; set; } = new();
        public List<string> Standardausrüstung { get; set; } = new();
        public List<string> ErlaubteKlassen { get; set; } = new();
        public List<string> WählbareBoni { get; set; } = new();
        public int MaxBoniauswahl { get; set; } = 3;
        public VolksBoni Boni { get; set; }
    }
}
