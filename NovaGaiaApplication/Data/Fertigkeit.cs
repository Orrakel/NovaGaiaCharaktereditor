namespace NovaGaiaCharaktereditor.Data
{
    public class Fertigkeit
    {
        public string Name { get; set; }
        public string Attribut { get; set; }
        public string Beschreibung { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Attribut})";
        }
    }

    public static class FertigkeitenDatenbank
    {
        public static List<Fertigkeit> Alle = new()
        {
            new() { Name = "Akrobatik", Attribut = "GE", Beschreibung = "Körperliche Geschicklichkeit wie Salti, Klettern oder Balanceakte." },
            new() { Name = "Arkanes Wissen", Attribut = "IN", Beschreibung = "Verstehen von mystischen Phänomenen, Energieflüssen und Geistern." },
            new() { Name = "Athletik", Attribut = "ST", Beschreibung = "Körperliche Stärke einsetzen, z. B. zum Springen, Tragen oder Kämpfen." },
            new() { Name = "Elementarmagie", Attribut = "variabel", Beschreibung = "Die gezielte Anwendung deines Elements im Kampf oder Alltag." },
            new() { Name = "Einschüchtern", Attribut = "CH", Beschreibung = "Andere mit Worten, Auftreten oder Taten einschüchtern." },
            new() { Name = "Einblick", Attribut = "WE", Beschreibung = "Gefühle, Lügen oder Absichten anderer erkennen." },
            new() { Name = "Erste Hilfe", Attribut = "WE", Beschreibung = "Rasche, lebensrettende Maßnahmen nach Verletzungen anwenden." },
            new() { Name = "Fahrzeugkunde", Attribut = "IN", Beschreibung = "Umgang mit Fahrzeugen wie Booten, Mechas oder Gleitern." },
            new() { Name = "Geisterwissen", Attribut = "WE", Beschreibung = "Wissen über die Andersweite, Geisterarten und spirituelle Zusammenhänge." },
            new() { Name = "Geschichte", Attribut = "IN", Beschreibung = "Wissen über vergangene Ereignisse, Kulturen und historische Figuren." },
            new() { Name = "Handwerk", Attribut = "IN/GE", Beschreibung = "Herstellung oder Reparatur von Gegenständen und Ausrüstung." },
            new() { Name = "Heimlichkeit", Attribut = "GE", Beschreibung = "Die Fähigkeit, sich unbemerkt zu bewegen oder etwas zu verbergen." },
            new() { Name = "Improvisation", Attribut = "CH", Beschreibung = "Spontane Ideen und Lösungen in schwierigen Situationen finden." },
            new() { Name = "Medizin", Attribut = "WE", Beschreibung = "Erste Hilfe leisten, Krankheiten behandeln, Heilkunde verstehen." },
            new() { Name = "Naturkunde", Attribut = "IN", Beschreibung = "Kenntnisse über Pflanzen, Tiere und natürliche Zusammenhänge." },
            new() { Name = "Performance", Attribut = "CH", Beschreibung = "Schauspiel, Musik oder Tanz zur Unterhaltung oder Ablenkung." },
            new() { Name = "Politik", Attribut = "IN", Beschreibung = "Verständnis für Machtstrukturen, Intrigen und Verhandlungen." },
            new() { Name = "Religion", Attribut = "WE", Beschreibung = "Wissen über spirituelle Bräuche, Rituale und Glaubenssysteme." },
            new() { Name = "Seemannschaft", Attribut = "ST", Beschreibung = "Schiffe steuern, Knoten binden und auf See navigieren." },
            new() { Name = "Sprengstoffkunde", Attribut = "IN", Beschreibung = "Kenntnisse über explosive Materialien und deren sichere Handhabung." },
            new() { Name = "Taktik", Attribut = "IN", Beschreibung = "Strategisches Denken im Kampf oder bei Planung komplexer Aktionen." },
            new() { Name = "Täuschung", Attribut = "CH", Beschreibung = "Lügen, verbergen oder sich verstellen, um andere zu täuschen." },
            new() { Name = "Technik", Attribut = "IN", Beschreibung = "Verstehen, Reparieren und Erfinden von technischen Geräten und Maschinen." },
            new() { Name = "Tierfreundschaft", Attribut = "CH", Beschreibung = "Den Umgang mit Tieren meistern, sie beruhigen oder trainieren." },
            new() { Name = "Überleben", Attribut = "WE", Beschreibung = "In der Wildnis überleben, Nahrung finden, Spuren lesen." },
            new() { Name = "Überreden", Attribut = "CH", Beschreibung = "Andere durch Worte, Charme oder Argumente überzeugen." },
            new() { Name = "Wahrheitsfindung", Attribut = "CH", Beschreibung = "Lügen erkennen und ehrliche Antworten erzwingen." },
            new() { Name = "Wahrnehmung", Attribut = "WE", Beschreibung = "Aufmerksames Beobachten der Umgebung, Geräusche, Gerüche oder Details erkennen." }
        };
    }
}
