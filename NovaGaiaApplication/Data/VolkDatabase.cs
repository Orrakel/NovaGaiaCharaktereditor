using NovaGaiaCharaktereditor.Data;
using NovaGaiaCharaktereditor.Klassen;
namespace NovaGaiaCharaktereditor
{
    public static class VolkDatabase
    {
        public static Dictionary<string, Volk> Voelker = new Dictionary<string, Volk>
        {
            ["Novani"] = new Volk
            {
                Name = "Novani",
                Beschreibung = "Streng gläubig, diszipliniert, Ursprung der Zivilisation.",
                Startattribute = new Dictionary<string, int>
                {
                    ["STR"] = 8,
                    ["GES"] = 8,
                    ["INT"] = 8,
                    ["WAH"] = 8,
                    ["AUS"] = 8,
                    ["WIL"] = 8,
                    ["CHR"] = 8
                },
                ErlaubteKlassen = new List<string> { "Wassermagie", "Erdmagie", "Feuermagie", "Luftmagie", "Techniker", "Krieger" },
                Vorteile = new List<string> { "Guter Anführer", "Glaube als Stärke", "Disziplinierte Ausbildung" },
                Nachteile = new List<string> { "Starrköpfig", "Arroganz gegenüber anderen Völkern", "Technologieverloren" },
                Boni = VolksboniDatabase.BoniProVolk["Novani"]
            },
            ["Psioniker"] = new Volk
            {
                Name = "Psioniker",
                Beschreibung = "Mental begabte Mutanten mit telepathischen Fähigkeiten.",
                Startattribute = new Dictionary<string, int>
                {
                    ["STR"] = 5,
                    ["GES"] = 9,
                    ["INT"] = 12,
                    ["WAH"] = 10,
                    ["AUS"] = 6,
                    ["WIL"] = 8,
                    ["CHR"] = 6
                },
                ErlaubteKlassen = new List<string> { "Wassermagie", "Erdmagie", "Feuermagie", "Luftmagie", "Techniker" },
                Vorteile = new List<string> { "Mentale Meisterschaft", "Telepathische Wahrnehmung", "Schweben" },
                Nachteile = new List<string> { "Körperlich schwach", "Ätherempfindlich", "Ausgeschlossen" },
                Boni = VolksboniDatabase.BoniProVolk["Psioniker"]
            },
            ["Bestarii"] = new Volk
            {
                Name = "Bestarii",
                Beschreibung = "Wilde Nomaden mit enger Bindung zu Tiergeistern.",
                Startattribute = new Dictionary<string, int>
                {
                    ["STR"] = 10,
                    ["GES"] = 10,
                    ["INT"] = 6,
                    ["WAH"] = 9,
                    ["AUS"] = 8,
                    ["WIL"] = 6,
                    ["CHR"] = 7
                },
                ErlaubteKlassen = new List<string> { "Wassermagie", "Erdmagie", "Feuermagie", "Luftmagie", "Krieger" },
                Vorteile = new List<string> { "Tierische Instinkte", "Seelenverbindung", "Natürliche Reflexe" },
                Nachteile = new List<string> { "Technikmisstrauen", "Eingeschränkte Freiheit", "Ehrenkodex" },
                Boni = VolksboniDatabase.BoniProVolk["Bestarii"]
            },
            ["Auralithen"] = new Volk
            {
                Name = "Auralithen",
                Beschreibung = "Eiswüstenbewohner mit robuster Konstitution und Eisaffinität.",
                Startattribute = new Dictionary<string, int>
                {
                    ["STR"] = 12,
                    ["GES"] = 7,
                    ["INT"] = 6,
                    ["WAH"] = 7,
                    ["AUS"] = 10,
                    ["WIL"] = 8,
                    ["CHR"] = 6
                },
                ErlaubteKlassen = new List<string> { "Wassermagie", "Erdmagie", "Feuermagie", "Techniker", "Krieger" },
                Vorteile = new List<string> { "Kälteresistenz", "Robuste Natur", "Meister der Eiszauber" },
                Nachteile = new List<string> { "Langsame Reflexe", "Misstrauen", "Hitzeschwäche" },
                Boni = VolksboniDatabase.BoniProVolk["Auralithen"]
            },
            ["Mareth"] = new Volk
            {
                Name = "Mareth",
                Beschreibung = "Wasserlebende Nachfahren der Bestarii mit amphibischen Fähigkeiten.",
                Startattribute = new Dictionary<string, int>
                {
                    ["STR"] = 8,
                    ["GES"] = 9,
                    ["INT"] = 8,
                    ["WAH"] = 8,
                    ["AUS"] = 9,
                    ["WIL"] = 7,
                    ["CHR"] = 7
                },
                ErlaubteKlassen = new List<string> { "Wassermagie", "Erdmagie", "Luftmagie", "Techniker", "Krieger" },
                Vorteile = new List<string> { "Unterwasseratmung", "+20% Bewegung im Wasser", "Druckresistenz" },
                Nachteile = new List<string> { "–10% Bewegung an Land", "Braucht regelmäßige Feuchtigkeit", "Traditionelles Denken" },
                Boni = VolksboniDatabase.BoniProVolk["Mareth"]
            },
            ["Steinvolk"] = new Volk
            {
                Name = "Steinvolk",
                Beschreibung = "Kristallverseuchte Unterirdische mit großer Standhaftigkeit und Magiespeicher.",
                Startattribute = new Dictionary<string, int>
                {
                    ["STR"] = 11,
                    ["GES"] = 6,
                    ["INT"] = 7,
                    ["WAH"] = 7,
                    ["AUS"] = 10,
                    ["WIL"] = 8,
                    ["CHR"] = 7
                },
                ErlaubteKlassen = new List<string> { "Wassermagie", "Erdmagie", "Feuermagie", "Techniker", "Krieger" },
                Vorteile = new List<string> { "Magiespeicher", "Harte Haut", "Unterirdische Orientierung" },
                Nachteile = new List<string> { "–10% Geschwindigkeit", "+10% Blitzschaden", "–10 auf soziale Proben" },
                Boni = VolksboniDatabase.BoniProVolk["Steinvolk"]
            },
            ["Sylvari"] = new Volk
            {
                Name = "Sylvari",
                Beschreibung = "Pflanzenverbundene Mutanten mit Heilfähigkeiten und Waldwissen.",
                Startattribute = new Dictionary<string, int>
                {
                    ["STR"] = 7,
                    ["GES"] = 9,
                    ["INT"] = 9,
                    ["WAH"] = 8,
                    ["AUS"] = 7,
                    ["WIL"] = 8,
                    ["CHR"] = 8
                },
                ErlaubteKlassen = new List<string> { "Wassermagie", "Erdmagie", "Luftmagie", "Techniker", "Krieger" },
                Vorteile = new List<string> { "Pflanzenkommunikation", "Natürliche Heilung", "+ auf Überleben im Wald" },
                Nachteile = new List<string> { "+10% Feuerschaden", "Weniger Heilung durch Fleisch", "–10% Bewegung auf gepflasterten Wegen" },
                Boni = VolksboniDatabase.BoniProVolk["Sylvari"]
            },
            ["Aetheris"] = new Volk
            {
                Name = "Aetheris",
                Beschreibung = "Gefiederte Hochlandbewohner mit Gleitfähigkeiten und erhöhter Sicht.",
                Startattribute = new Dictionary<string, int>
                {
                    ["STR"] = 7,
                    ["GES"] = 10,
                    ["INT"] = 9,
                    ["WAH"] = 9,
                    ["AUS"] = 7,
                    ["WIL"] = 7,
                    ["CHR"] = 7
                },
                ErlaubteKlassen = new List<string> { "Wassermagie", "Feuermagie", "Luftmagie", "Techniker", "Krieger" },
                Vorteile = new List<string> { "Gleitflug", "Erweiterte Sicht", "Bonus gegen Fallschaden" },
                Nachteile = new List<string> { "Empfindlich gegen starken Wind", "–3 Rüstung", "–5 auf Stärkeproben" },
                Boni = VolksboniDatabase.BoniProVolk["Aetheris"]
            }
        };
    }
}