namespace NovaGaiaCharaktereditor
{
    public class Merkmal
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public int Punkte { get; set; } // Positive Werte = Nachteil, Negative = Vorteil (Kosten)
    }

    public static class MerkmaleDatenbank
    {
        public static List<Merkmal> Alle = new()
        {
            new Merkmal { Name = "Äthergespür", Beschreibung = "Du spürst magische Ströme und Kristalle in deiner Nähe.", Punkte = -3 },
            new Merkmal { Name = "Entfernungssinn", Beschreibung = "Entfernungen sind dir immer bekannt.", Punkte = -1 },
            new Merkmal { Name = "Fuchssinn", Beschreibung = "Anschleichen ist bei dir nur schwer möglich.", Punkte = -3 },
            new Merkmal { Name = "Geborener Redner", Beschreibung = "Sozialwürfe um 15 erleichtert.", Punkte = -4 },
            new Merkmal { Name = "Geweihter", Beschreibung = "Du bist dir sicher, es ist für etwas gut.", Punkte = -2 },
            new Merkmal { Name = "Gutes Gedächtnis", Beschreibung = "Du kannst dir Namen und Informationen besser merken.", Punkte = -2 },
            new Merkmal { Name = "Gute Reflexe", Beschreibung = "Das Ausweichen und Blocken ist um 25% erleichtert.", Punkte = -4 },
            new Merkmal { Name = "Kristallbindung", Beschreibung = "Du kannst bestimmte Kristalle besser nutzen (+20% Effizienz).", Punkte = -4 },
            new Merkmal { Name = "Logisches Denken", Beschreibung = "Du erhältst 5 Tipps.", Punkte = -3 },
            new Merkmal { Name = "Nerven aus Stahl", Beschreibung = "In schwierigen Situationen kannst du die Ruhe bewahren.", Punkte = -3 },
            new Merkmal { Name = "Orientierung", Beschreibung = "Für dich ist Norden immer erkennbar.", Punkte = -1 },
            new Merkmal { Name = "Pragmatiker", Beschreibung = "Du nimmst in vielen Situationen mehr wahr, ohne extra darauf zu würfeln.", Punkte = -3 },
            new Merkmal { Name = "Prinzipientreue", Beschreibung = "Du hältst an deinen Prinzipien fest und lässt dich nur schwer umstimmen.", Punkte = -2 },
            new Merkmal { Name = "Robust", Beschreibung = "Die Rüstung ist von Natur aus um 3 erhöht.", Punkte = -3 },
            new Merkmal { Name = "Sanftheit", Beschreibung = "Menschen lassen sich leichter von dir beruhigen und vertrauen dir schneller.", Punkte = -3 },
            new Merkmal { Name = "Schicksalsgläubig", Beschreibung = "Einmal pro Tag einen Wurf wiederholen.", Punkte = -4 },
            new Merkmal { Name = "Schimmernde Präsenz", Beschreibung = "Eindrucksvolle oder anziehende Aura.", Punkte = -4 },
            new Merkmal { Name = "Schneller Lerner", Beschreibung = "Doppelte XP bei neuen Fähigkeiten.", Punkte = -5 },
            new Merkmal { Name = "Spirituelles Gleichgewicht", Beschreibung = "Erhöhte Regenerationsgeschwindigkeit.", Punkte = -3 },
            new Merkmal { Name = "Stahlmagen", Beschreibung = "Du kannst alles essen, egal wie schlecht es schmeckt oder ob es verdorben ist.", Punkte = -2 },
            new Merkmal { Name = "Stets Willkommen", Beschreibung = "Menschen heißen dich fast immer willkommen.", Punkte = -3 },
            new Merkmal { Name = "Teamgeist", Beschreibung = "Bonus auf Gruppenaktionen.", Punkte = -2 },
            new Merkmal { Name = "Technologisches Gespür", Beschreibung = "Artefakte sind intuitiver verständlich.", Punkte = -3 },
            new Merkmal { Name = "Tierfreund", Beschreibung = "Tiere vertrauen dir schneller.", Punkte = -2 },
            new Merkmal { Name = "Trinkfest", Beschreibung = "Mit Alkohol hast du wenig Probleme.", Punkte = -2 },
            new Merkmal { Name = "Unscheinbar", Beschreibung = "Du kannst in der Masse untertauchen, ohne aufzufallen.", Punkte = -2 },
            new Merkmal { Name = "Wenig Schläfer", Beschreibung = "Erhöht den durch die Rast wiederhergestellten Wert.", Punkte = -3 },
            new Merkmal { Name = "Widerstandskraft", Beschreibung = "Resistent gegen Effekte wie Kälte, Hitze oder Gift (10% Reduktion).", Punkte = -3 },
            new Merkmal { Name = "Witterungsfest", Beschreibung = "Wetterbedingungen machen dir wenig aus.", Punkte = -2 },
            new Merkmal { Name = "Zeitgefühl", Beschreibung = "Du weißt immer, wie spät es ist.", Punkte = -1 },

            // Nachteile
            new Merkmal { Name = "Ätherabhängig", Beschreibung = "Ohne Ätherquellen sind alle Würfe um 10 erschwert.", Punkte = 3 },
            new Merkmal { Name = "Ätherüberladung", Beschreibung = "Zu viel Äther verursacht Beschwerden.", Punkte = 3 },
            new Merkmal { Name = "Analphabet", Beschreibung = "Du kannst nicht lesen.", Punkte = 3 },
            new Merkmal { Name = "Angst vor", Beschreibung = "Würfe um 30 erschwert.", Punkte = 3 },
            new Merkmal { Name = "Antike Abneigung", Beschreibung = "Schwierigkeiten mit moderner Technologie.", Punkte = 2 },
            new Merkmal { Name = "Arrogant", Beschreibung = "Soziale Interaktion um 20 erschwert.", Punkte = 2 },
            new Merkmal { Name = "Auffällig", Beschreibung = "Du kannst dich nicht verstecken oder schleichen.", Punkte = 2 },
            new Merkmal { Name = "Berühmtheit", Beschreibung = "Fast jeder kennt dich.", Punkte = 2 },
            new Merkmal { Name = "Dauerhafte Präsenz", Beschreibung = "Menschen vergessen dich nicht.", Punkte = 2 },
            new Merkmal { Name = "Dicke Finger", Beschreibung = "Fingerfertigkeiten sind stark eingeschränkt.", Punkte = 3 },
            new Merkmal { Name = "Empfindliches Gehör", Beschreibung = "Probleme mit lauten Geräuschen, Würfe um 10 erschwert.", Punkte = 2 },
            new Merkmal { Name = "Gehasst", Beschreibung = "Menschen mögen dich nicht schnell.", Punkte = 3 },
            new Merkmal { Name = "Gesucht", Beschreibung = "Polizei kennt dich.", Punkte = 3 },
            new Merkmal { Name = "Höhenangst", Beschreibung = "Probleme in großen Höhen, Würfe um 20 erschwert.", Punkte = 3 },
            new Merkmal { Name = "Isolationist", Beschreibung = "Unwohlsein unter Fremden.", Punkte = 2 },
            new Merkmal { Name = "Kaufsüchtig", Beschreibung = "Du willst so viel wie möglich kaufen.", Punkte = 1 },
            new Merkmal { Name = "Kleptomanie", Beschreibung = "Du hast den Drang, Dinge mitzunehmen.", Punkte = 2 },
            new Merkmal { Name = "Kristallanfälligkeit", Beschreibung = "Kristallkontakt verursacht Erschöpfung.", Punkte = 2 },
            new Merkmal { Name = "Landratte", Beschreibung = "Probleme auf Booten/Flugzeugen, Würfe um 15 erschwert.", Punkte = 2 },
            new Merkmal { Name = "Lichtempfindlich", Beschreibung = "Probleme bei hellem Licht, Würfe um 15 erschwert.", Punkte = 2 },
            new Merkmal { Name = "Misstrauen der Alten", Beschreibung = "Ältere NPCs haben Vorurteile.", Punkte = 2 },
            new Merkmal { Name = "Naiv", Beschreibung = "Du vertraust schneller.", Punkte = 1 },
            new Merkmal { Name = "Nachtblind", Beschreibung = "Probleme in dunklen Orten, Würfe um 10 erschwert.", Punkte = 2 },
            new Merkmal { Name = "Nimmersatt", Beschreibung = "Du brauchst immer etwas zu essen.", Punkte = 1 },
            new Merkmal { Name = "Orientierungslos", Beschreibung = "50% Chance, dich zu verlaufen.", Punkte = 3 },
            new Merkmal { Name = "Perfektionist", Beschreibung = "Du musst alles zu Ende bringen.", Punkte = 2 },
            new Merkmal { Name = "Pingeliger Esser", Beschreibung = "Du kannst nicht alles essen.", Punkte = 1 },
            new Merkmal { Name = "Platzangst", Beschreibung = "Probleme in engen Orten, Würfe um 10 erschwert.", Punkte = 2 },
            new Merkmal { Name = "Schwere Rüstung", Beschreibung = "Langsamkeit bei schwerer Rüstung.", Punkte = 1 },
            new Merkmal { Name = "Selbstgespräche", Beschreibung = "25% Chance, Pläne laut auszusprechen.", Punkte = 1 },
            new Merkmal { Name = "Selbstüberschätzend", Beschreibung = "Du überschätzt dich oft.", Punkte = 2 },
            new Merkmal { Name = "Schnell verliebt", Beschreibung = "Du verliebst dich schnell.", Punkte = 1 },
            new Merkmal { Name = "Streitsüchtig", Beschreibung = "Du suchst schnell Streit.", Punkte = 2 },
            new Merkmal { Name = "Verwundbarkeit gegen Pflanzenmagie", Beschreibung = "Pflanzenangriffe wirken stärker.", Punkte = 2 },
            new Merkmal { Name = "Zersplittertes Gedächtnis", Beschreibung = "Alte Erinnerungen verwirren dich.", Punkte = 2 },
            new Merkmal { Name = "Zweifler", Beschreibung = "Schwierigkeiten, an höhere Mächte zu glauben.", Punkte = 2 },
        };
    }
}