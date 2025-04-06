using NovaGaiaCharaktereditor.Data;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NovaGaiaCharaktereditor
{
    public partial class MainWindow : Window
    {
        private Charakter aktuellerCharakter;
        private string characterFolder;
        private int punkte = 0;
        private int verfügbareAttributPunkte = 27;
        private readonly List<string> basisAttribute = new() { "STR", "GES", "INT", "WAH", "AUS", "WIL", "CHR" };
        private int maxBonusAuswahl = 0;
        private List<BoniEintrag> aktiveVolksBoni = new();

        public MainWindow()
        {
            InitializeComponent();
            characterFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Characters");
            if (!Directory.Exists(characterFolder)) Directory.CreateDirectory(characterFolder);

            aktuellerCharakter = new Charakter();
            cmbVolk.ItemsSource = VolkDatabase.Voelker.Keys;
            cmbAlleVorteile.ItemsSource = MerkmaleDatenbank.Alle.FindAll(m => m.Punkte < 0);
            cmbAlleVorteile.ItemTemplate = (DataTemplate)FindResource("MerkmalTemplate");
            cmbAlleNachteile.ItemsSource = MerkmaleDatenbank.Alle.FindAll(m => m.Punkte > 0);
            cmbAlleNachteile.ItemTemplate = (DataTemplate)FindResource("MerkmalTemplate");
            txtAttributpunkte.Text = $"Verfügbare Punkte: {punkte}";
            cmbKlasse.SelectionChanged += cmbKlasse_SelectionChanged;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(aktuellerCharakter.Name))
                aktuellerCharakter.Name = txtName.Text.Trim();

            aktuellerCharakter.Motivation = txtMotivation.Text.Trim();
            _ = int.TryParse(txtLevel.Text, out int level);
            aktuellerCharakter.Level = level;

            if (int.TryParse(txtLebenAktuell.Text, out int lebenAktuell))
                aktuellerCharakter.LebenAktuell = lebenAktuell;

            if (int.TryParse(txtChiAktuell.Text, out int chiAktuell))
                aktuellerCharakter.ChiAktuell = chiAktuell;

            string path = Path.Combine(characterFolder, aktuellerCharakter.Name + ".json");
            string json = JsonSerializer.Serialize(aktuellerCharakter, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
            MessageBox.Show("Charakter gespeichert.");
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                InitialDirectory = characterFolder,
                Filter = "Charakterdateien (*.json)|*.json"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    string json = File.ReadAllText(dialog.FileName);
                    aktuellerCharakter = JsonSerializer.Deserialize<Charakter>(json);

                    if (aktuellerCharakter != null)
                    {
                        txtName.Text = aktuellerCharakter.Name;
                        txtMotivation.Text = aktuellerCharakter.Motivation;
                        txtLevel.Text = aktuellerCharakter.Level.ToString();
                        txtLebenAktuell.Text = aktuellerCharakter.LebenAktuell.ToString();
                        txtChiAktuell.Text = aktuellerCharakter.ChiAktuell.ToString();
                        RenderFaehigkeiten();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Laden: " + ex.Message);
                }
            }
        }
        private void cmbVolk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbVolk.SelectedItem is string selectedVolk &&
                VolkDatabase.Voelker.TryGetValue(selectedVolk, out var volk))
            {
                aktuellerCharakter.Volk = volk;

                // Attribute setzen
                aktuellerCharakter.Attribute = new Dictionary<string, int>(volk.Startattribute);

                // Reset der festen Vorteile/Nachteile
                aktuellerCharakter.FesteVorteile = new List<string>(volk.Vorteile);
                aktuellerCharakter.FesteNachteile = new List<string>(volk.Nachteile);

                // Doppelte entfernen (falls Benutzer z. B. vorher selbst dieselben hinzugefügt hat)
                aktuellerCharakter.Vorteile.RemoveAll(v => aktuellerCharakter.FesteVorteile.Contains(v));
                aktuellerCharakter.Nachteile.RemoveAll(n => aktuellerCharakter.FesteNachteile.Contains(n));

                // Beschreibung aktualisieren
                txtVolkBeschreibung.Text = volk.Beschreibung;

                // Klassen neu setzen
                cmbKlasse.ItemsSource = volk.ErlaubteKlassen;
                cmbKlasse.SelectedIndex = -1;

                // Fähigkeiten-Ansicht zurücksetzen
                faehigkeitenPanel.Children.Clear();
                aktuellerCharakter.Fähigkeiten.Clear();

                // Inventar mit Standardausrüstung des Volkes
                txtInventar.Text = string.Join(Environment.NewLine, volk.Standardausrüstung ?? new List<string>());

                // Attributpunkte zurücksetzen
                UpdateAttributAnzeige();

                // Merkmalslisten aktualisieren
                UpdateMerkmalsListen();

                // Update Volksboni
                LadeVolksBoni(volk);
            }
        }

        private void UpdateVolksbonusHinweis()
        {
            int max = aktuellerCharakter.Volk?.MaxBoniauswahl ?? 0;
            int aktuell = aktuellerCharakter.VolksBoni.Count;

            txtVolksBoniHinweis.Text = $"Ausgewählt: {aktuell} / {max}";
        }

        private void UpdateMerkmalsListen()
        {
            // Vorteile anzeigen: Feste zuerst, dann benutzerdefinierte
            lstVorteile.ItemsSource = null;
            lstVorteile.ItemsSource = aktuellerCharakter.FesteVorteile
                .Concat(aktuellerCharakter.Vorteile)
                .ToList();

            // Nachteile anzeigen: Feste zuerst, dann benutzerdefinierte
            lstNachteile.ItemsSource = null;
            lstNachteile.ItemsSource = aktuellerCharakter.FesteNachteile
                .Concat(aktuellerCharakter.Nachteile)
                .ToList();
        }


        private void cmbKlasse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbKlasse.SelectedItem is string klasse)
            {
                aktuellerCharakter.Klasse = klasse;

                // Nur Klasse setzen, Fähigkeiten nicht direkt übernehmen
                aktuellerCharakter.Fähigkeiten = new List<Fähigkeit>();
                RenderFaehigkeiten();
            }
        }

        private void BtnAddFaehigkeiten_Click(object sender, RoutedEventArgs e)
        {
            // Sicherstellen, dass eine Klasse ausgewählt ist
            if (string.IsNullOrWhiteSpace(aktuellerCharakter?.Klasse) ||
                !KlassenFaehigkeiten.VerfuegbareFaehigkeiten.TryGetValue(aktuellerCharakter.Klasse, out var faehigkeitenTuples))
            {
                MessageBox.Show("Bitte wähle zuerst eine Klasse mit verfügbaren Fähigkeiten.");
                return;
            }

            // Bereits gewählte Fähigkeiten herausfiltern
            var bereitsGewählt = aktuellerCharakter.Fähigkeiten.Select(f => f.Name).ToHashSet();

            // Konvertiere Tuple in Fähigkeit-Objekte und filtere bereits gewählte
            var verfügbareFähigkeiten = faehigkeitenTuples
                .Where(f => !bereitsGewählt.Contains(f.Name))
                .Select(f => new Fähigkeit
                {
                    Name = f.Name,
                    Effekt = f.Effekt,
                    ChiKosten = f.ChiKosten
                })
                .ToList();

            if (verfügbareFähigkeiten.Count == 0)
            {
                MessageBox.Show("Alle verfügbaren Fähigkeiten dieser Klasse wurden bereits hinzugefügt.");
                return;
            }

            // Dialog aufrufen
            var dialog = new FähigkeitAuswahlDialog(verfügbareFähigkeiten);
            if (dialog.ShowDialog() == true && dialog.SelectedFähigkeit != null)
            {
                aktuellerCharakter.Fähigkeiten.Add(dialog.SelectedFähigkeit);
                RenderFaehigkeiten();
            }
        }

        private void RenderFaehigkeiten()
        {
            if (FindName("faehigkeitenPanel") is not StackPanel panel || aktuellerCharakter?.Fähigkeiten == null)
                return;

            panel.Children.Clear();

            foreach (var f in aktuellerCharakter.Fähigkeiten)
            {
                panel.Children.Add(new Label
                {
                    Content = $"Name: {f.Name}",
                    FontWeight = FontWeights.Bold,
                    FontSize = 14
                });

                panel.Children.Add(new Label
                {
                    Content = $"Effekt: {f.Effekt}",
                    Margin = new Thickness(0, 0, 0, 2)
                });

                panel.Children.Add(new Label
                {
                    Content = $"Chi-Kosten: {f.ChiKosten}",
                    Margin = new Thickness(0, 0, 0, 10)
                });
            }
        }

        private void chkSpielmodus_Checked(object sender, RoutedEventArgs e)
        {
            SetBearbeitungsmodus(false); // Spielmodus
        }

        private void chkSpielmodus_Unchecked(object sender, RoutedEventArgs e)
        {
            SetBearbeitungsmodus(true); // Bearbeiten
        }

        private void SetBearbeitungsmodus(bool bearbeitbar)
        {
            // Textfelder deaktivieren
            txtName.IsReadOnly = !bearbeitbar;
            txtMotivation.IsReadOnly = !bearbeitbar;
            txtLevel.IsReadOnly = !bearbeitbar;

            foreach (var attr in basisAttribute)
            {
                var box = this.FindName("txt_" + attr) as TextBox;
                if (box != null)
                {
                    box.IsReadOnly = !bearbeitbar;
                }
            }

            // ComboBoxen
            cmbVolk.IsEnabled = bearbeitbar;
            cmbKlasse.IsEnabled = bearbeitbar;
            cmbAlleVorteile.IsEnabled = bearbeitbar;
            cmbAlleNachteile.IsEnabled = bearbeitbar;

            // Buttons deaktivieren/aktivieren
            BtnAddVorteil.IsEnabled = bearbeitbar;
            BtnAddNachteil.IsEnabled = bearbeitbar;
            BtnRemoveVorteil.IsEnabled = bearbeitbar;
            BtnRemoveNachteil.IsEnabled = bearbeitbar;
            BtnAddFaehigkeiten.IsEnabled = bearbeitbar;
            BtnRemoveFaehigkeit.IsEnabled = bearbeitbar;
            BtnSave.IsEnabled = bearbeitbar;

            // Optional: auch andere Eingaben oder Custom-Funktionen sperren
        }

        private void BtnRemoveFaehigkeit_Click(object sender, RoutedEventArgs e)
        {
            if (aktuellerCharakter.Fähigkeiten == null || aktuellerCharakter.Fähigkeiten.Count == 0)
            {
                MessageBox.Show("Es wurden noch keine Fähigkeiten ausgewählt.");
                return;
            }

            // Dialog zur Auswahl der zu entfernenden Fähigkeit
            var dialog = new FähigkeitAuswahlDialog(aktuellerCharakter.Fähigkeiten);
            dialog.Title = "Fähigkeit entfernen";

            if (dialog.ShowDialog() == true && dialog.SelectedFähigkeit != null)
            {
                var zuEntfernen = aktuellerCharakter.Fähigkeiten
                    .FirstOrDefault(f => f.Name == dialog.SelectedFähigkeit.Name);

                if (zuEntfernen != null)
                {
                    aktuellerCharakter.Fähigkeiten.Remove(zuEntfernen);
                    RenderFaehigkeiten();
                }
            }
        }

        private void BtnAddVorteil_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAlleVorteile.SelectedItem is Merkmal merkmal)
            {
                AddMerkmal(merkmal);
                txtAttributpunkte.Text = $"Verfügbare Punkte: {punkte}";
            }
        }

        private void BtnAddNachteil_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAlleNachteile.SelectedItem is Merkmal merkmal)
            {
                AddMerkmal(merkmal);
                txtAttributpunkte.Text = $"Verfügbare Punkte: {punkte}";
            }
        }

        private void BtnRemoveVorteil_Click(object sender, RoutedEventArgs e)
        {
            if (lstVorteile.SelectedItem is string selected)
            {
                var merkmal = MerkmaleDatenbank.Alle.Find(m => selected.StartsWith(m.Name));
                if (merkmal != null)
                {
                    aktuellerCharakter.Vorteile.Remove(selected);
                    punkte -= merkmal.Punkte;
                    lstVorteile.ItemsSource = null;
                    lstVorteile.ItemsSource = new List<string>(aktuellerCharakter.Vorteile);
                    txtAttributpunkte.Text = $"Verfügbare Punkte: {punkte}";
                }
            }
        }

        private void BtnRemoveNachteil_Click(object sender, RoutedEventArgs e)
        {
            if (lstNachteile.SelectedItem is string selected)
            {
                var merkmal = MerkmaleDatenbank.Alle.Find(m => selected.StartsWith(m.Name));
                if (merkmal != null)
                {
                    aktuellerCharakter.Nachteile.Remove(selected);
                    punkte -= merkmal.Punkte;
                    lstNachteile.ItemsSource = null;
                    lstNachteile.ItemsSource = new List<string>(aktuellerCharakter.Nachteile);
                    txtAttributpunkte.Text = $"Verfügbare Punkte: {punkte}";
                }
            }
        }

        private void AddMerkmal(Merkmal merkmal)
        {
            if (merkmal.Punkte < 0)
            {
                if (aktuellerCharakter.Vorteile.Count >= 7)
                {
                    MessageBox.Show("Maximal 7 Vorteile erlaubt.");
                    return;
                }
                aktuellerCharakter.Vorteile.Add($"{merkmal.Name} ({-merkmal.Punkte}P)");
                punkte += merkmal.Punkte;
                lstVorteile.ItemsSource = null;
                lstVorteile.ItemsSource = new List<string>(aktuellerCharakter.Vorteile);
            }
            else
            {
                if (aktuellerCharakter.Nachteile.Count >= 7)
                {
                    MessageBox.Show("Maximal 7 Nachteile erlaubt.");
                    return;
                }
                aktuellerCharakter.Nachteile.Add($"{merkmal.Name} ({merkmal.Punkte}P)");
                punkte += merkmal.Punkte;
                lstNachteile.ItemsSource = null;
                lstNachteile.ItemsSource = new List<string>(aktuellerCharakter.Nachteile);
            }
        }

        private void UpdateAttributAnzeige()
        {
            foreach (var attr in basisAttribute)
            {
                var modLabel = this.FindName("mod_" + attr) as Label;
                if (modLabel != null)
                {
                    int mod = aktuellerCharakter.GetModifikator(attr);
                    modLabel.Content = mod >= 0 ? $"+{mod}" : mod.ToString();
                }
            }

            foreach (var attr in basisAttribute)
            {
                var label = this.FindName("lbl_" + attr) as Label;
                var box = this.FindName("txt_" + attr) as TextBox;
                if (label != null) label.Content = attr;
                if (box != null) box.Text = aktuellerCharakter.Attribute.ContainsKey(attr) ? aktuellerCharakter.Attribute[attr].ToString() : "0";
            }

            var txtLebenMax = this.FindName("txtLebenMax") as TextBlock;
            var txtLebenAktuell = this.FindName("txtLebenAktuell") as TextBox;
            if (txtLebenMax != null) txtLebenMax.Text = aktuellerCharakter.Leben.ToString();
            if (txtLebenAktuell != null && string.IsNullOrWhiteSpace(txtLebenAktuell.Text))
                txtLebenAktuell.Text = aktuellerCharakter.Leben.ToString();

            var txtChiMax = this.FindName("txtChiMax") as TextBlock;
            var txtChiAktuell = this.FindName("txtChiAktuell") as TextBox;
            if (txtChiMax != null) txtChiMax.Text = aktuellerCharakter.Chi.ToString();
            if (txtChiAktuell != null && string.IsNullOrWhiteSpace(txtChiAktuell.Text))
                txtChiAktuell.Text = aktuellerCharakter.Chi.ToString();

            var txtRKBox = this.FindName("txtRK") as TextBlock;
            if (txtRKBox != null) txtRKBox.Text = aktuellerCharakter.Ruestungsklasse.ToString();

            // Verfügbare Punkte
            int level = aktuellerCharakter.Level;
            int maxPunkte = 80 + ((level - 1) * 2);
            int gesamtVerteilt = 0;

            foreach (var attr in basisAttribute)
            {
                var box = this.FindName("txt_" + attr) as TextBox;
                if (box != null && int.TryParse(box.Text, out int val))
                    gesamtVerteilt += val;
            }

            int verfügbarePunkte = maxPunkte - gesamtVerteilt;

            var punkteText = this.FindName("txtAttributpunkte") as TextBlock;
            if (punkteText != null)
                punkteText.Text = $"Verfügbare Attributspunkte: {verfügbarePunkte}";

        }

        private void SetTheme(string themeName)
        {
            var uri = new Uri($"Themes/{themeName}Theme.xaml", UriKind.Relative);
            var newTheme = new ResourceDictionary { Source = uri };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        private void ThemeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (ThemeSelector.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (!string.IsNullOrEmpty(selected))
                SetTheme(selected);
            else
            {
                aktuellerCharakter.VolksBoni = aktiveVolksBoni.Select(b => b.Name).ToList();
            }

            UpdateBonusCheckBoxes();
        }
        private void UpdateBonusCheckBoxes()
        {
            if (lstFreieVolksBoni == null)
                return;

            foreach (var item in lstFreieVolksBoni.Items)
            {
                var container = lstFreieVolksBoni.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter;
                if (container == null) continue;

                var checkbox = FindVisualChild<CheckBox>(container);

                if (checkbox != null)
                {
                    checkbox.IsEnabled = chkSpielmodus.IsChecked != true &&
                                         (checkbox.IsChecked == true || aktiveVolksBoni.Count < maxBonusAuswahl);
                }
            }
        }
        private void LadeVolksBoni(Volk volk)
        {
            if (volk?.Boni != null)
            {
                lstFesteVolksBoni.ItemsSource = volk.Boni.FesteBoni;
                lstFreieVolksBoni.ItemsSource = volk.Boni.FreieBoni;

                // Bonus-Auswahl Info aktualisieren
                txtVolksBoniHinweis.Text = $"Wähle bis zu {maxBonusAuswahl} Bonus{(maxBonusAuswahl > 1 ? "e" : "")}.";
            }
            else
            {
                // Hinweis, wenn keine Volksboni vorhanden sind
                txtVolksBoniHinweis.Text = "Keine Volksboni verfügbar.";
            }
        }

        // Event-Handler für das Hinzufügen von Volksboni
        private void BtnAddVolksBoni_Click(object sender, RoutedEventArgs e)
        {
            if (lstFreieVolksBoni.SelectedItems.Count > 0)
            {
                foreach (var item in lstFreieVolksBoni.SelectedItems)
                {
                    lstFesteVolksBoni.Items.Add(item);  // Volksboni zu den festen Boni hinzufügen
                }
            }
            else
            {
                MessageBox.Show("Bitte wähle mindestens einen Bonus aus.");
            }
        }

        // Event-Handler für das Entfernen von Volksboni
        private void BtnRemoveVolksBoni_Click(object sender, RoutedEventArgs e)
        {
            if (lstFesteVolksBoni.SelectedItem != null)
            {
                lstFesteVolksBoni.Items.Remove(lstFesteVolksBoni.SelectedItem);  // Entferne den gewählten Bonus
            }
            else
            {
                MessageBox.Show("Bitte wähle einen Bonus zum Entfernen aus.");
            }
        }


        private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                    return typedChild;

                T result = FindVisualChild<T>(child);
                if (result != null)
                    return result;
            }
            return null;
        }

        private void AttributeGeändert(object sender, TextChangedEventArgs e)
        {
            if (aktuellerCharakter is null) return;

            if (sender is TextBox levelBox && levelBox.Name == "txtLevel")
            {
                if (int.TryParse(levelBox.Text, out int level))
                {
                    aktuellerCharakter.Level = level;
                    UpdateAttributAnzeige();
                }
                return;
            }

            if (sender is TextBox box && box.Name.StartsWith("txt_"))
            {
                string key = box.Name.Replace("txt_", "");
                if (int.TryParse(box.Text, out int value))
                {
                    aktuellerCharakter.Attribute[key] = value;
                    verfügbareAttributPunkte = 27;
                    foreach (var attr in basisAttribute)
                    {
                        if (aktuellerCharakter.Attribute.TryGetValue(attr, out int attrValue))
                        {
                            int kosten = attrValue - (aktuellerCharakter.Volk?.Startattribute.ContainsKey(attr) == true ? aktuellerCharakter.Volk.Startattribute[attr] : 0);
                            verfügbareAttributPunkte -= kosten;
                        }
                    }
                    UpdateAttributAnzeige();
                }
            }
        }
    }

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
    public class VolksBoni
    {
        public List<BoniEintrag> FesteBoni { get; set; } = new();
        public List<BoniEintrag> FreieBoni { get; set; } = new();
        public int MaxBoniauswahl { get; set; }
    }

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
