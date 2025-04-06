using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaGaiaCharaktereditor.Klassen
{
    public class Charakter
    {
        public string Name { get; set; } = string.Empty;
        public Volk Volk { get; set; }
        public string Klasse { get; set; } = string.Empty;
        public Dictionary<string, int> Attribute { get; set; } = new();
        public List<string> Vorteile { get; set; } = new();
        public List<string> Nachteile { get; set; } = new();
        public string Motivation { get; set; } = string.Empty;
        public int Level { get; set; } = 1;
        public int LebenAktuell { get; set; }
        public int ChiAktuell { get; set; }
        public List<Fähigkeit> Fähigkeiten { get; set; } = new();
        public List<string> FesteVorteile { get; set; } = new();
        public List<string> FesteNachteile { get; set; } = new();
        public List<string> VolksBoni { get; set; } = new();
        public List<string> Fertigkeiten { get; set; } = new();


        public int Leben
        {
            get
            {
                int konsti = Attribute.ContainsKey("AUS") ? Attribute["AUS"] : 0;
                int mod = GetModifikator("AUS");
                int basis = 0;

                if (Klasse.Contains("Magie")) basis = 8;
                else if (Klasse == "Krieger") basis = 10;
                else if (Klasse == "Techniker") basis = 6;
                else basis = 5;

                return basis + konsti + mod + (Level - 1) * mod;
            }
        }

        public int Chi => 5 + GetModifikator("WIL") + Level;

        public int Ruestungsklasse
        {
            get
            {
                int basis = 10;
                int geschick = GetModifikator("GES");
                int bonus = 0;
                if (Vorteile.Exists(v => v.Contains("Robust"))) bonus += 3;
                return basis + geschick + bonus;
            }
        }

        public int GetModifikator(string attribut)
        {
            if (Attribute != null && Attribute.TryGetValue(attribut, out int wert))
            {
                return (wert - 10) / 2;
            }
            return 0;
        }
    }
}
