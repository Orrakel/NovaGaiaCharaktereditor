namespace NovaGaiaCharaktereditor.Data
{
    public static class VolksboniDatabase
    {
        public static Dictionary<string, VolksboniSet> BoniProVolk { get; } = new()
        {
            {
                "Novani",
                new VolksboniSet
                {
                    MaxBoniauswahl = 3,
                    FesteBoni = new List<BoniEintrag>
                    {
                        new BoniEintrag { Name = "Glaubensresonanz", Beschreibung = "Kann einmal pro Tag einen Fehlschlag bei einem sozialen Wurf wiederholen, wenn er mit Glauben oder Überzeugung zu tun hat." },
                        new BoniEintrag { Name = "Zentrale Kultur", Beschreibung = "Erhält bei Interaktionen mit anderen Völkern +5 auf soziale Würfe, da die meisten mit Novani vertraut sind." },
                        new BoniEintrag { Name = "Disziplinierte Ausbildung", Beschreibung = "Beginnt mit einem zusätzlichen Talent auf „Geübt“ in einem gewählten Bereich." },
                    },
                    FreieBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Resilienz durch Glauben", Beschreibung = "+10 auf Willenskraft gegen Furcht, mentale Beeinflussung oder Versuchung." },
                        new() { Name = "Starke Hierarchie", Beschreibung = "Kann Novani-Angehörige leichter überzeugen oder führen." },
                        new() { Name = "Zivile Organisation", Beschreibung = "10 % Bonus auf wirtschaftliche und organisatorische Aufgaben." },
                        new() { Name = "Taktisches Denken", Beschreibung = "Kleiner Bonus auf strategische Planungen in Kämpfen oder Verhandlungen." },
                        new() { Name = "Gesetzeskenner", Beschreibung = "Bessere Chancen, rechtliche oder diplomatische Konflikte zu lösen." },
                        new() { Name = "Zeremonielle Präsenz", Beschreibung = "Beginnt mit religiösem Gegenstand, der in bestimmten Situationen Boni gibt." },
                        new() { Name = "Inspirierender Glaube", Beschreibung = "Verbündete erhalten +10 auf nächsten Willenskraftwurf nach inspirierender Rede." },
                        new() { Name = "Ritualkenntnis", Beschreibung = "Kann einfache Rituale durchführen, um kleine Boni zu erhalten." },
                        new() { Name = "Vergessene Technologie", Beschreibung = "Kleine Chance, alte Artefakte zu verstehen oder reaktivieren." },
                        new() { Name = "Hierarchisches Denken", Beschreibung = "Formuliert Befehle/Strategien klarer für bessere Gruppenaktionen." },
                        new() { Name = "Glaubensprüfung", Beschreibung = "Einmalige mentale Herausforderung für Bonus auf Verteidigung." },
                        new() { Name = "Wächter der Schriften", Beschreibung = "Kann uraltes Wissen nutzen, um Situationen zu lösen." },
                        new() { Name = "Tempelgeweiht", Beschreibung = "Erhält Vorteile in heiligen Novani-Tempeln." },
                        new() { Name = "Strenge Disziplin", Beschreibung = "+15 auf Konzentration oder mentale Herausforderungen." },
                        new() { Name = "Prophetische Vision", Beschreibung = "Einmal pro Abenteuer vage Hinweise auf Gefahr oder Möglichkeit." },
                        new() { Name = "Uralte Meditationspraktiken", Beschreibung = "Meditation verleiht leichten Buff." },
                        new() { Name = "Glaube als Schutzschild", Beschreibung = "Kann Schutz durch Glaubenskraft aktivieren." }
                    }
                }
            },
            {
                "Psioniker",
                new VolksboniSet
                {
                    MaxBoniauswahl = 3,
                    FesteBoni = new List<BoniEintrag>
                    {
                        new BoniEintrag { Name = "Mentales Echo", Beschreibung = "Kann Fragmente der Gedanken anderer empfangen." },
                        new BoniEintrag { Name = "Psychische Welle", Beschreibung = "Kann einmal pro Tag einen Feind in Desorientierung versetzen." },
                        new BoniEintrag { Name = "Ätherresonanz", Beschreibung = "+10 % schnellere Manaregeneration bei Ätherquelle." },
                    },
                    FreieBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Kollektive Intelligenz", Beschreibung = "+5 Intelligenzbonus in Gruppen von Psionikern." },
                        new() { Name = "Telekinetischer Schub", Beschreibung = "Kann kleine Objekte (bis zu 5 kg) für kurze Zeit telekinetisch bewegen." },
                        new() { Name = "Gedankenflüstern", Beschreibung = "Telepathische Kommunikation mit einer nahen Person ohne Worte." },
                        new() { Name = "Zerbrechliche Realität", Beschreibung = "Erzeugt kurze Illusionen zur Ablenkung." },
                        new() { Name = "Psychoanalyse", Beschreibung = "+10 auf Menschenkenntnis und Lügen erkennen." },
                        new() { Name = "Schweben", Beschreibung = "Kann für einige Sekunden in der Luft bleiben." },
                        new() { Name = "Mentaler Schutz", Beschreibung = "Resistenz gegen psychische Angriffe oder Manipulation." },
                        new() { Name = "Erhöhte Wahrnehmung", Beschreibung = "Erkennt versteckte magische oder mentale Einflüsse leichter." },
                        new() { Name = "Gehirnkapazität", Beschreibung = "Erhöhte Informationsspeicherung und Merkfähigkeit." },
                        new() { Name = "Astrale Projektion", Beschreibung = "Geist verlässt den Körper und reist unsichtbar (1×/Woche, 100 m)." },
                        new() { Name = "Aura-Lesen", Beschreibung = "Erkennt mit Konzentration Emotionen und Intentionen anderer." },
                        new() { Name = "Geistige Fusion", Beschreibung = "Kann für kurze Zeit Gedanken und Wissen mit einem Verbündeten teilen." },
                        new() { Name = "Verstärkte Meditation", Beschreibung = "Meditation beschleunigt Manaregeneration um 50 % (30 Minuten)." },
                        new() { Name = "Zukunftsfragment", Beschreibung = "Gelegentliche intuitive Vorahnungen über drohende Gefahren." },
                        new() { Name = "Psi-Energie entladen", Beschreibung = "Leichte psychische Welle, die Gegner zurückstößt." },
                        new() { Name = "Kinetischer Reflex", Beschreibung = "Instinktives Schutzschild, das einen Angriff abwehrt." },
                        new() { Name = "Geisterblick", Beschreibung = "Kann für kurze Zeit durch feste Objekte schemenhaft sehen." },
                        new() { Name = "Äthermanipulation", Beschreibung = "Beeinflusst minimale Ätherflüsse (z. B. Licht verändern)." },
                        new() { Name = "Mentale Signatur", Beschreibung = "Wird von anderen unbewusst übersehen, wirkt unauffällig." },
                        new() { Name = "Energetische Synchronisation", Beschreibung = "Verbindet sich mit Ätherquelle, um Fähigkeiten zu verstärken (Cooldown 12h/Quelle)." },
                        new() { Name = "Höhere Gehirnfrequenz", Beschreibung = "+20 auf Intelligenzwürfe nach Vorbereitung durch Fokussierung." }
                    }
                }
            },
            {
                "Bestarii",
                new VolksboniSet
                {
                    MaxBoniauswahl = 3,
                    FesteBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Seelenverbindung", Beschreibung = "Beginnt mit einem tierischen Begleiter, mit dem er mental verbunden ist und dessen Verhalten er beeinflussen kann." },
                        new() { Name = "Instinktiver Fluchtreflex", Beschreibung = "+10 auf Ausweichen, wenn sie von einem Überraschungsangriff getroffen werden." },
                        new() { Name = "Tierkommunikation", Beschreibung = "Kann mit nicht-intelligenten Tieren grundlegende Absichten austauschen (Freund, Feind, Gefahr)." }
                    },
                    FreieBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Rudelführer", Beschreibung = "Verbündete Tiere erhalten +5 auf ihre Aktionen in der Nähe des Bestarii." },
                        new() { Name = "Natürliche Reflexe", Beschreibung = "+20 auf Initiativewürfe." },
                        new() { Name = "Anpassung an die Umwelt", Beschreibung = "Erhöhte Resistenz gegen natürliche Wetterbedingungen (Kälte, Hitze, Luftfeuchtigkeit)." },
                        new() { Name = "Natürliche Jäger", Beschreibung = "+5 Wahrnehmung bei Wildnisaktionen zur Jagd oder Spurensuche." },
                        new() { Name = "Leise Bewegung", Beschreibung = "+10 auf Schleichen in Wäldern oder Savannen." },
                        new() { Name = "Instinktive Kampfweise", Beschreibung = "+5 auf Angriffe mit improvisierten Waffen oder im Nahkampf." },
                        new() { Name = "Wilde Regeneration", Beschreibung = "Heilt 10 % schneller, wenn er in der Natur ruht." },
                        new() { Name = "Tierische Beweglichkeit", Beschreibung = "Verbessertes Klettern, Springen und Bewegen in unwegsamem Gelände." },
                        new() { Name = "Überlebenskunst", Beschreibung = "+10 auf Überlebensfähigkeiten wie Feuer machen oder essbare Pflanzen erkennen." },
                        new() { Name = "Blutband", Beschreibung = "Einmal pro Tag gehorcht der Tierbegleiter sofort (um 20 erleichtert)." },
                        new() { Name = "Vertrauter der Wildnis", Beschreibung = "Wilde Tiere greifen seltener an, solange keine Bedrohung ausgeht." },
                        new() { Name = "Tarnung des Jägers", Beschreibung = "Kann sich für kurze Zeit nahezu unsichtbar machen in natürlicher Umgebung." },
                        new() { Name = "Blutrausch", Beschreibung = "+10 % Stärke-Bonus, wenn verletzt oder Kampf länger dauert." },
                        new() { Name = "Tiersinne", Beschreibung = "Kann einmal täglich die Sinne eines Tieres teilen." },
                        new() { Name = "Kampf mit Krallen", Beschreibung = "Verwendet Klauen oder Fingernägel als Waffen für zusätzlichen Schaden." },
                        new() { Name = "Verbunden mit der Erde", Beschreibung = "Spürt Erschütterungen und erkennt Bewegungen frühzeitig." },
                        new() { Name = "Wilde Heilung", Beschreibung = "Kann aus Naturmaterialien einfache Heilmittel herstellen." },
                        new() { Name = "Tierähnlicher Kampfgeist", Beschreibung = "Bessere Verteidigung oder schnellere Angriffe in Extremsituationen." },
                        new() { Name = "Jäger der Nacht", Beschreibung = "Verbesserte Nachtsicht und lautlose Bewegung im Dunkeln." },
                        new() { Name = "Wilde Entschlossenheit", Beschreibung = "3 Runden resistent gegen lähmende oder geistige Effekte." },
                        new() { Name = "Aggressive Präsenz", Beschreibung = "Kann durch wilde Ausstrahlung in sozialen Situationen einschüchtern." },
                        new() { Name = "Tierkampfstil", Beschreibung = "Unvorhersehbarer Kampfstil wie Raubtiere, erschwert Vorhersagen des Gegners." },
                        new() { Name = "Spurloser Wanderer", Beschreibung = "Hinterlässt kaum Spuren, schwer zu verfolgen in der Wildnis." }
                    }
                }
            },
            {
                "Mareth",
                new VolksboniSet
                {
                    MaxBoniauswahl = 3,
                    FesteBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Kommunikation mit Meereswesen", Beschreibung = "Kann einfache Signale und Absichten mit Meerestieren austauschen." },
                        new() { Name = "Flexibles Skelett", Beschreibung = "Kann sich in enge Spalten oder durch kleine Öffnungen zwängen." },
                        new() { Name = "Tiefseetaucher", Beschreibung = "Kann unbegrenzt unter Wasser atmen und bewegt sich dort genauso schnell wie an Land." }
                    },
                    FreieBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Wellenläufer", Beschreibung = "Kann für bis zu 5 Sekunden über Wasser rennen." },
                        new() { Name = "Hydrodynamischer Körper", Beschreibung = "+10 % Bewegungsgeschwindigkeit im Wasser." },
                        new() { Name = "Druckresistenz", Beschreibung = "Kein zusätzlicher Schaden durch Wasserdruck oder Tiefe." },
                        new() { Name = "Biolumineszenz", Beschreibung = "Kann Körperteile zum Leuchten bringen für Orientierung oder Signale." },
                        new() { Name = "Meeresinstinkt", Beschreibung = "+5 Wahrnehmung unter Wasser zur Gefahren- oder Objektentdeckung." },
                        new() { Name = "Flüssigkeitsregulation", Beschreibung = "Braucht weniger Wasser, um hydriert zu bleiben." },
                        new() { Name = "Gezeitenwissen", Beschreibung = "Erkennt Veränderungen von Wellen, Strömung und Wetter frühzeitig." },
                        new() { Name = "Strömungskontrolle", Beschreibung = "Kann leichte Wasserströmungen manipulieren (z. B. Ablenkungen erzeugen)." },
                        new() { Name = "Wasserheilung", Beschreibung = "Erhöhte Regeneration um 10 % in Wasserumgebung." },
                        new() { Name = "Schleimhautsekretion", Beschreibung = "Macht Haut einmal täglich rutschig, um nicht gepackt zu werden." },
                        new() { Name = "Aquatische Tarnung", Beschreibung = "Kann sich unter Wasser besser verstecken, wenn er stillhält." },
                        new() { Name = "Kiemenverengung", Beschreibung = "Reduziert Sauerstoffverbrauch für tiefe oder sauerstoffarme Gebiete." },
                        new() { Name = "Meeresrufer", Beschreibung = "Kann durch Töne bestimmte Meereslebewesen anlocken oder beruhigen." },
                        new() { Name = "Flossenverstärkung", Beschreibung = "Temporär drastisch erhöhte Schwimmgeschwindigkeit." },
                        new() { Name = "Kühle Haut", Beschreibung = "Besserer Hitzeschutz in warmem Klima." },
                        new() { Name = "Tiefensehvermögen", Beschreibung = "Besseres Sehen in dunklen oder trüben Gewässern." },
                        new() { Name = "Algenaffinität", Beschreibung = "Kann mit Meeresalgen interagieren, sie wachsen lassen oder nutzen." }
                    }
                }
            },
            {
                "Auralithen",
                new VolksboniSet
                {
                    MaxBoniauswahl = 3,
                    FesteBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Eiskristallrüstung", Beschreibung = "Einmal am Tag für 2 Stunden kann ein natürlicher Eispanzer aktiviert werden, der 10 % des erlittenen Schadens reduziert." },
                        new() { Name = "Polaradaptation", Beschreibung = "Hat keine Bewegungseinschränkungen auf Schnee oder Eis." },
                        new() { Name = "Gefrorenes Blut", Beschreibung = "Erhält +5 Widerstand gegen Vergiftungseffekte." }
                    },
                    FreieBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Natürlicher Kälteschutz", Beschreibung = "Immun gegen Erfrierungen, Kälte-Effekte und extreme Minusgrade." },
                        new() { Name = "Frostgriff", Beschreibung = "Einmal pro Tag kann eine Waffe für kurze Zeit Frostschaden verursachen (+10 Eisschaden)." },
                        new() { Name = "Eisige Entschlossenheit", Beschreibung = "+10 auf Willenskraft bei Schmerzen oder mentalen Beeinflussungen." },
                        new() { Name = "Nordische Konstitution", Beschreibung = "Braucht weniger Nahrung und Wasser in kalten Regionen." },
                        new() { Name = "Winterläufer", Beschreibung = "Kann sich ohne Einschränkungen auf vereisten Flächen bewegen." },
                        new() { Name = "Schneegeboren", Beschreibung = "Kann Schnee und Eis instinktiv als Deckung oder Waffe nutzen." },
                        new() { Name = "Gefrorene Aura", Beschreibung = "Temperatur sinkt leicht in der Umgebung, Gegner können verlangsamt werden." },
                        new() { Name = "Stählerner Körper", Beschreibung = "+5 natürliche Rüstung gegen stumpfe Angriffe." },
                        new() { Name = "Meister der Eiszauber", Beschreibung = "Beginnt mit einer einfachen Eisfähigkeit (z. B. Frostnebel erzeugen)." },
                        new() { Name = "Frostschritt", Beschreibung = "Kann sich auf zerbrechlichem Eis bewegen, indem er es unter sich gefrieren lässt." },
                        new() { Name = "Kälteabsorption", Beschreibung = "Kann Kälteenergie aufnehmen und dadurch leicht heilen." },
                        new() { Name = "Eisiger Blick", Beschreibung = "Kann bei Augenkontakt eine leichte Kältestarre hervorrufen." },
                        new() { Name = "Nordische Kampftechnik", Beschreibung = "Bonus im Umgang mit Zweihandwaffen und improvisierten Eiswaffen." },
                        new() { Name = "Gletscherherz", Beschreibung = "Erhöhte mentale Resistenz gegen Angst und emotionale Manipulation." },
                        new() { Name = "Permafrosthaut", Beschreibung = "Kurzzeitige Feuerresistenz einmal pro Rast (+10 % Hitzeresistenz)." },
                        new() { Name = "Atem des Nordens", Beschreibung = "Einmal täglich ein frostiger Windstoß, der Gegner zurückstoßen kann." },
                        new() { Name = "Eisskulpturen", Beschreibung = "Kann instinktiv Eis formen, z. B. zu Werkzeugen oder Waffen." },
                        new() { Name = "Harsche Winterdisziplin", Beschreibung = "Hält körperlich länger durch, ohne erschöpft zu werden." },
                        new() { Name = "Verhärtetes Fleisch", Beschreibung = "+3 natürliche Rüstung gegen Schnitt- und Stichwaffen." },
                        new() { Name = "Tiefschlaf", Beschreibung = "Regeneriert schneller im Schlaf bei extremer Kälte." },
                        new() { Name = "Blizzard-Sinne", Beschreibung = "Kann Schneestürme und Temperaturwechsel frühzeitig erkennen." },
                        new() { Name = "Eisader", Beschreibung = "Spürt natürliche Eisadern, nutzbar für Magie oder Ressourcen." },
                        new() { Name = "Gletscherbrecher", Beschreibung = "Kann Eis oder gefrorenen Boden zerstören, um Wege freizulegen." },
                        new() { Name = "Wärmeablehnung", Beschreibung = "Braucht weniger Wasser, schwitzt kaum – ideal für Kälteklima." },
                        new() { Name = "Unerschütterliche Präsenz", Beschreibung = "+5 Willenskraft für Verbündete in der Nähe." }
                    }
                }
            },
            {
                "Aetheris",
                new VolksboniSet
                {
                    MaxBoniauswahl = 3,
                    FesteBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Schwebesprung", Beschreibung = "Kann von hohen Orten langsam herabschweben, ohne Fallschaden zu nehmen." },
                        new() { Name = "Luftbewusstsein", Beschreibung = "+5 auf Wahrnehmung für sich bewegende Objekte in der Luft." },
                        new() { Name = "Gleitflug", Beschreibung = "Kann kurze Strecken in der Luft segeln." }
                    },
                    FreieBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Winde des Schicksals", Beschreibung = "Einmal täglich eine Windböe, um Angriffe oder Projektile abzulenken." },
                        new() { Name = "Luftige Reflexe", Beschreibung = "Bonus auf Ausweichwürfe gegen Fernkampfangriffe." },
                        new() { Name = "Akrobatische Beweglichkeit", Beschreibung = "Besseres Abstoßen, Festhalten, Drehen in Bewegung." },
                        new() { Name = "Aufwind-Meister", Beschreibung = "Schneller rennen oder höher springen in offenen/bergigen Regionen." },
                        new() { Name = "Luftstromlenkung", Beschreibung = "Kontrolliert leichte Windströmungen zur Ablenkung oder Tarnung." },
                        new() { Name = "Geringes Gewicht", Beschreibung = "Bewegt sich mühelos auf instabilen Flächen." },
                        new() { Name = "Federresistenz", Beschreibung = "Reduzierter Fallschaden, schnelle Erholung nach einem Sturz." },
                        new() { Name = "Windtänzer", Beschreibung = "Im Nahkampf schwerer zu treffen durch flexible Bewegung." },
                        new() { Name = "Luftkampfexperte", Beschreibung = "Bonus für Bewegungen in der Luft beim Kampf." },
                        new() { Name = "Aufwind-Kick", Beschreibung = "Sprungtritt mit Windenergie wirft Gegner zu Boden." },
                        new() { Name = "Äthergleiten", Beschreibung = "Kann sich mit magischen Windströmen zu Zielen ziehen." },
                        new() { Name = "Luftsprung", Beschreibung = "Erzeugt zweiten Impuls in der Luft für größere Sprünge." },
                        new() { Name = "Winde der Stille", Beschreibung = "Dämpft Geräusche für 60 Sekunden, um unentdeckt zu bleiben." },
                        new() { Name = "Luftdruckkontrolle", Beschreibung = "Verändert Luftdruck kurzzeitig für Bewegung oder Gegnerbeeinflussung." },
                        new() { Name = "Falkensicht", Beschreibung = "Besserer Überblick aus der Höhe." },
                        new() { Name = "Wetterfühligkeit", Beschreibung = "Frühe Wahrnehmung von Wetterveränderungen." },
                        new() { Name = "Windträger", Beschreibung = "Kann sich passiv mit Windströmungen fortbewegen." },
                        new() { Name = "Aura der Lüfte", Beschreibung = "Schwerer ortbar durch veränderte Präsenz." },
                        new() { Name = "Ätherische Stöße", Beschreibung = "Erzeugt kleine Luftimpulse, um Objekte zu bewegen oder Gegner zu stören." },
                        new() { Name = "Luftwirbel-Schutz", Beschreibung = "Einmal täglich ein Windstoß, der einen Angriff abwehrt." },
                        new() { Name = "Levitationsinstinkt", Beschreibung = "Kurzzeitiger Schwerelosigkeitszustand zur Überwindung von Hindernissen." },
                        new() { Name = "Himmelsgesang", Beschreibung = "Erzeugt Schwingungen, die Mechanismen oder magische Luft-Effekte beeinflussen können." }
                    }
                }
            },
            {
                "Sylvari",
                new VolksboniSet
                {
                    MaxBoniauswahl = 3,
                    FesteBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Schnelles Wachstum", Beschreibung = "Kann kleine Pflanzen schneller wachsen lassen (z. B. Ranken, Wurzeln)." },
                        new() { Name = "Chlorophyllhaut", Beschreibung = "Regeneriert langsam Lebenspunkte bei Tageslicht." },
                        new() { Name = "Dschungelverschmelzung", Beschreibung = "+10 auf Tarnung in bewaldeten Gebieten." }
                    },
                    FreieBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Biolumineszenz", Beschreibung = "Kann Haut oder Haare zum Leuchten bringen." },
                        new() { Name = "Tief verwurzelt", Beschreibung = "+10 auf Standfestigkeit gegen Umwerfen oder Verschieben." },
                        new() { Name = "Dschungeläther", Beschreibung = "Kann Äther in Pflanzen speichern und später nutzen." },
                        new() { Name = "Erweiterte Sinne", Beschreibung = "Spürt Temperatur, Feuchtigkeit und Wachstum von Pflanzen." },
                        new() { Name = "Sprachgewandtheit der Natur", Beschreibung = "Kann mit Pflanzen kommunizieren oder sie deuten." },
                        new() { Name = "Anpassung an extreme Umgebungen", Beschreibung = "Resistenz gegen natürliche Gifte und schlechte Nahrung." },
                        new() { Name = "Giftige Blüten", Beschreibung = "Kann einmal pro Tag lähmende oder betäubende Substanzen absondern." },
                        new() { Name = "Heilende Berührung", Beschreibung = "Kann kleine Wunden über Pflanzenkontakt heilen." },
                        new() { Name = "Rankengriff", Beschreibung = "Kann feine Ranken wachsen lassen, um Objekte zu greifen oder Gegner zu fesseln." },
                        new() { Name = "Dornenschutz", Beschreibung = "+3 Rüstung durch stachelige Rinde für 60 Minuten aktivierbar." },
                        new() { Name = "Waldläufer-Instinkt", Beschreibung = "Schneller und leiser durch dichte Vegetation bewegbar." },
                        new() { Name = "Ätherblüte", Beschreibung = "Konzentriert Äther in Pflanzen für magische Effekte." },
                        new() { Name = "Naturheiliger", Beschreibung = "Verstärkt natürliche Heilwirkung von Pflanzen." },
                        new() { Name = "Samenbombe", Beschreibung = "Erzeugt kleine, ablenkende oder einschüchternde Samenhülsen." },
                        new() { Name = "Wurzelnetzwerk", Beschreibung = "Spürt Bewegungen durch Vibrationen im Boden." },
                        new() { Name = "Wachstumsschub", Beschreibung = "Kann einmal pro Tag eine Pflanze dramatisch wachsen lassen." },
                        new() { Name = "Blätterhaut", Beschreibung = "Kann Hautfarbe an Umgebung anpassen (Tarnung)." },
                        new() { Name = "Pflanzenmimikry", Beschreibung = "Kann Aussehen an lokale Flora angleichen." },
                        new() { Name = "Parasitische Verbindung", Beschreibung = "Kann Eigenschaften gefährlicher Pflanzen übernehmen." },
                        new() { Name = "Pollenflug", Beschreibung = "Setzt Pollenwolke frei, die Gegner verwirrt oder blendet." },
                        new() { Name = "Waldwächter", Beschreibung = "Erhält Boni, wenn er lange in derselben natürlichen Umgebung verweilt." },
                        new() { Name = "Blattmetabolismus", Beschreibung = "Kann Energie direkt aus Pflanzen oder Sonnenlicht ziehen." },
                        new() { Name = "Ätherisches Blühen", Beschreibung = "Lässt schützende Blume wachsen, die einen Angriff absorbiert." },
                        new() { Name = "Baumverbundenheit", Beschreibung = "Verbindung mit einem Baum gewährt passive Vorteile (z. B. Regeneration)." }
                    }
                }
            },
            {
                "Steinvolk",
                new VolksboniSet
                {
                    MaxBoniauswahl = 3,
                    FesteBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Erdverbindung", Beschreibung = "Kann für eine Runde vollständig stillstehen und erhält +10 auf Verteidigung für den restlichen Kampf." },
                        new() { Name = "Resonanzhaut", Beschreibung = "Kann einmal pro Tag einen feindlichen Magieangriff um 10 % reflektieren." },
                        new() { Name = "Bergbewohner", Beschreibung = "Bewegung in felsigem Terrain kostet keine Extra-Bewegungspunkte." }
                    },
                    FreieBoni = new List<BoniEintrag>
                    {
                        new() { Name = "Harte Haut", Beschreibung = "+5 natürliche Rüstung gegen nicht-magische Angriffe." },
                        new() { Name = "Magiespeicher", Beschreibung = "Kann Äther in Körperkristallen speichern und später nutzen." },
                        new() { Name = "Widerstand gegen Erdmagie", Beschreibung = "10 % Resistenz gegen erd- oder steinbasierte Angriffe." },
                        new() { Name = "Unnachgiebig", Beschreibung = "Kann nicht durch normale Angriffe umgeworfen oder gestört werden." },
                        new() { Name = "Untergrundsicht", Beschreibung = "Kann in dunklen Höhlen oder Gängen problemlos navigieren." },
                        new() { Name = "Steinsprache", Beschreibung = "Spürt Vibrationen im Boden und erkennt Bewegungen oder Höhlen." },
                        new() { Name = "Kristallbindung", Beschreibung = "+20 % Effizienz bei Kristalltechnologie." },
                        new() { Name = "Naturgegebene Standhaftigkeit", Beschreibung = "+5 Willenskraft gegen Manipulation und Einschüchterung." },
                        new() { Name = "Schwere Schritte", Beschreibung = "Steuert Gewicht zur Geräuschlosigkeit oder zum Erschüttern des Bodens." },
                        new() { Name = "Erdmantel", Beschreibung = "Kann sich mit Stein überziehen und +10 Rüstung für 1 Runde erhalten." },
                        new() { Name = "Kristallschmied", Beschreibung = "Kann Kristalle instinktiv zu Werkzeugen oder Konstruktionen formen." },
                        new() { Name = "Schwingungsleser", Beschreibung = "Erkennt versteckte Gegner oder Erdbeben durch Erdberührung." },
                        new() { Name = "Steinfaust", Beschreibung = "Hände können verhärtet werden für waffenlose Angriffe." },
                        new() { Name = "Gesteinsfresser", Beschreibung = "Regeneration durch Konsum kleiner Mengen von Mineralien/Metallen." },
                        new() { Name = "Lavabeständigkeit", Beschreibung = "Verminderter Feuerschaden, kann heißes Gestein berühren." },
                        new() { Name = "Felsformung", Beschreibung = "Kann kleinere Felsen bewegen oder formen." },
                        new() { Name = "Kristallreflexion", Beschreibung = "Reflektiert Licht, um zu blenden oder zu signalisieren." },
                        new() { Name = "Unzerstörbare Geduld", Beschreibung = "Kann lange bewegungslos verweilen ohne Nachteil." },
                        new() { Name = "Magnetischer Instinkt", Beschreibung = "Kann metallische Objekte in der Nähe spüren." },
                        new() { Name = "Tiefenruhe", Beschreibung = "20 % schnellere Regeneration in Höhlen oder Untergrund." },
                        new() { Name = "Felswiderstand", Beschreibung = "Resistenz gegen Erdrutsche, Beben und physische Schocks." },
                        new() { Name = "Knochen aus Erz", Beschreibung = "Sehr hohe Widerstandskraft gegen Knochenbrüche." },
                        new() { Name = "Höhlenkenner", Beschreibung = "Kann unterirdische Strukturen intuitiv kartieren." },
                        new() { Name = "Bodenerschütterung", Beschreibung = "Erzeugt Staubwolke oder Erschütterung durch kräftigen Tritt." },
                        new() { Name = "Geologisches Wissen", Beschreibung = "Instinktives Verständnis von Mineralien und Gestein." },
                        new() { Name = "Resistenz gegen Lärm", Beschreibung = "Weniger anfällig für laute Geräusche oder Explosionen." }
                    }
                }
            },
        };
    }

    public class VolksboniSet
    {
        public List<BoniEintrag> FesteBoni { get; set; } = new();
        public List<BoniEintrag> FreieBoni { get; set; } = new();
        public int MaxBoniauswahl { get; set; }
    }

    public class BoniEintrag
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }
    }
}