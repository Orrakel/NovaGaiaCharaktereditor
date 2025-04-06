using NovaGaiaCharaktereditor.Data;
using NovaGaiaCharaktereditor.Klassen;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;
using NovaGaiaCharaktereditor.HelpDialog;



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
        private List<Fähigkeit> aktiveFaehigkeiten = new();
        private List<Fertigkeit> aktiveFertigkeiten = new();
        private Dictionary<string, int> neueAttribute = new();

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
            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Charakterdateien (*.json)|*.json",
                DefaultExt = ".json"
            };

            if (dialog.ShowDialog() == true)
            {
                aktuellerCharakter.Name = txtName.Text;
                aktuellerCharakter.Motivation = txtMotivation.Text;
                aktuellerCharakter.Klasse = cmbKlasse.SelectedItem?.ToString();
                var volkName = cmbVolk.SelectedItem?.ToString();
                aktuellerCharakter.Level = int.TryParse(txtLevel.Text, out int level) ? level : 1;

                if (volkName != null && VolkDatabase.Voelker.TryGetValue(volkName, out var volk))
                {
                    aktuellerCharakter.Volk = volk;
                }

                // Übertragen der Live-Daten
                aktuellerCharakter.Fähigkeiten = aktiveFaehigkeiten;
                aktuellerCharakter.VolksBoni = aktiveVolksBoni.Select(b => b.Name).ToList();
                aktuellerCharakter.Fertigkeiten = aktiveFertigkeiten.Select(f => f.Name).ToList();
                aktuellerCharakter.Vorteile = lstVorteile.Items.Cast<string>().ToList();
                aktuellerCharakter.Nachteile = lstNachteile.Items.Cast<string>().ToList();

                // Attribute
                aktuellerCharakter.Attribute = neueAttribute.ToDictionary(entry => entry.Key, entry => entry.Value);

                var json = JsonConvert.SerializeObject(aktuellerCharakter, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(dialog.FileName, json);

                MessageBox.Show("Charakter wurde erfolgreich gespeichert.");
            }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Charakterdateien (*.json)|*.json",
                DefaultExt = ".json"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var json = File.ReadAllText(dialog.FileName);
                    aktuellerCharakter = JsonConvert.DeserializeObject<Charakter>(json) ?? new Charakter();

                    // Textfelder
                    txtName.Text = aktuellerCharakter.Name;
                    txtMotivation.Text = aktuellerCharakter.Motivation;

                    cmbKlasse.SelectedItem = aktuellerCharakter.Klasse;
                    cmbVolk.SelectedItem = aktuellerCharakter.Volk?.Name;

                    if (aktuellerCharakter.Volk != null)
                    {
                        LadeVolksBoni(aktuellerCharakter.Volk);

                        aktiveVolksBoni = aktuellerCharakter.Volk.Boni.FreieBoni
                            .Where(b => aktuellerCharakter.VolksBoni.Contains(b.Name))
                            .ToList();

                        RenderVolksboni();
                    }

                    // ComboBoxen vorbereiten
                    cmbKlasse.ItemsSource = KlassenFaehigkeiten.VerfuegbareFaehigkeiten.Keys.ToList();
                    cmbVolk.ItemsSource = VolkDatabase.Voelker.Keys.ToList();

                    // Daten setzen
                    cmbKlasse.SelectedItem = aktuellerCharakter.Klasse;
                    cmbVolk.SelectedItem = aktuellerCharakter.Volk?.Name;
                    txtLevel.Text = aktuellerCharakter.Level.ToString();
                    txtLevel.Text = aktuellerCharakter.Level.ToString();

                    // Attribute
                    neueAttribute = new Dictionary<string, int>(aktuellerCharakter.Attribute);
                    UpdateAttributAnzeige();

                    // Fähigkeiten
                    aktiveFaehigkeiten = aktuellerCharakter.Fähigkeiten ?? new();
                    RenderFaehigkeiten();

                    // Fertigkeiten
                    aktiveFertigkeiten = FertigkeitenDatenbank.Alle
                        .Where(f => aktuellerCharakter.Fertigkeiten.Contains(f.Name))
                        .ToList();
                    RenderFertigkeiten();

                    // Volksboni
                    if (VolkDatabase.Voelker.TryGetValue(aktuellerCharakter.Volk.Name, out var geladenesVolk))
                    {
                        LadeVolksBoni(geladenesVolk);
                        aktiveVolksBoni = geladenesVolk.Boni.FreieBoni
                            .Where(b => aktuellerCharakter.VolksBoni.Contains(b.Name))
                            .ToList();
                        RenderVolksboni();
                    }

                    // Vorteile & Nachteile
                    lstVorteile.ItemsSource = aktuellerCharakter.Vorteile;
                    lstNachteile.ItemsSource = aktuellerCharakter.Nachteile;

                    MessageBox.Show("Charakter erfolgreich geladen.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Laden: {ex.Message}");
                }
            }
        }

        private void cmbVolk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbVolk.SelectedItem is string selectedVolk &&
                VolkDatabase.Voelker.TryGetValue(selectedVolk, out var volk))
            {
                aktuellerCharakter.Volk = volk;
                aktuellerCharakter.Attribute = new Dictionary<string, int>(volk.Startattribute);
                verfügbareAttributPunkte = 27;
                UpdateAttributAnzeige();

                // Aktualisiere UI
                txtVolkBeschreibung.Text = volk.Beschreibung;
                cmbKlasse.ItemsSource = volk.ErlaubteKlassen;
                cmbKlasse.SelectedIndex = -1;

                // Lade Volksboni
                LadeVolksBoni(volk);

                //// Leere Fähigkeiten-Listen
                //lstAlleFähigkeiten.ItemsSource = KlassenFaehigkeiten.VerfuegbareFaehigkeiten.GetValueOrDefault(volk.Name, new());
                //lstAusgewaehlteTechniken.ItemsSource = null;
            }

            lstVorteile.ItemsSource = new List<string>(aktuellerCharakter.Vorteile);
            lstNachteile.ItemsSource = new List<string>(aktuellerCharakter.Nachteile);
        }

        private void BtnAddVolksBoni_Click(object sender, RoutedEventArgs e)
        {
            if (aktuellerCharakter.Volk?.Boni == null) return;

            var max = aktuellerCharakter.Volk.Boni.MaxBoniauswahl;
            var aktuelle = aktiveVolksBoni.Select(b => b.Name).ToHashSet();
            var verfügbare = aktuellerCharakter.Volk.Boni.FreieBoni
                .Where(b => !aktuelle.Contains(b.Name))
                .ToList();

            if (aktiveVolksBoni.Count >= max)
            {
                MessageBox.Show($"Du hast bereits {max} freie Boni gewählt.");
                return;
            }

            var dialog = new VolksboniAuswahlDialog(verfügbare, max);

            if (dialog.ShowDialog() == true && dialog.AusgewählteBoni.Any())
            {
                aktiveVolksBoni.AddRange(dialog.AusgewählteBoni);
                aktuellerCharakter.VolksBoni = aktiveVolksBoni.Select(b => b.Name).ToList();
                RenderVolksboni();
            }
        }

        private void RenderVolksboni()
        {
            lstAusgewaehlteVolksBoni.ItemsSource = null;
            lstAusgewaehlteVolksBoni.ItemsSource = aktiveVolksBoni;
            txtVolksBoniHinweis.Text = $"Ausgewählt: {aktiveVolksBoni.Count} / {maxBonusAuswahl}";
        }

        private void LadeVolksBoni(Volk volk)
        {
            if (volk?.Boni != null)
            {
                lstFesteVolksBoni.ItemsSource = volk.Boni.FesteBoni;
                lstAusgewaehlteVolksBoni.ItemsSource = aktiveVolksBoni;

                aktiveVolksBoni.Clear();
                maxBonusAuswahl = volk.Boni.MaxBoniauswahl;

                txtVolksBoniHinweis.Text = $"Wähle bis zu {maxBonusAuswahl} freie Bonus{(maxBonusAuswahl > 1 ? "e" : "")}.";
            }
            else
            {
                lstFesteVolksBoni.ItemsSource = null;
                lstAusgewaehlteVolksBoni.ItemsSource = null;
                txtVolksBoniHinweis.Text = "Keine Volksboni verfügbar.";
            }
        }

        private void BtnAddFertigkeiten_Click(object sender, RoutedEventArgs e)
        {
            var maxFertigkeiten = 4; // ggf. klassenspezifisch setzen
            var bereitsGewählt = aktiveFertigkeiten.Select(f => f.Name).ToHashSet();

            var verfügbare = FertigkeitenDatenbank.Alle
                .Where(f => !bereitsGewählt.Contains(f.Name))
                .ToList();

            var dialog = new NovaGaiaCharaktereditor.Dialoge.FertigkeitenAuswahlDialog(verfügbare, maxFertigkeiten);

            if (dialog.ShowDialog() == true && dialog.AusgewaehlteFertigkeiten.Any())
            {
                aktiveFertigkeiten.AddRange(dialog.AusgewaehlteFertigkeiten);
                aktuellerCharakter.Fertigkeiten = aktiveFertigkeiten.Select(f => f.Name).ToList();
                RenderFertigkeiten();
            }
        }

        private void BtnRemoveFertigkeiten_Click(object sender, RoutedEventArgs e)
        {
            if (lstAusgewaehlteFertigkeiten.SelectedItem is Fertigkeit ausgewählte)
            {
                aktiveFertigkeiten.Remove(ausgewählte);
                aktuellerCharakter.Fertigkeiten = aktiveFertigkeiten.Select(f => f.Name).ToList();
                RenderFertigkeiten();
            }
            else
            {
                MessageBox.Show("Bitte wähle eine Fertigkeit aus, die entfernt werden soll.");
            }
        }

        private void RenderFertigkeiten()
        {
            lstAusgewaehlteFertigkeiten.ItemsSource = null;
            lstAusgewaehlteFertigkeiten.ItemsSource = aktiveFertigkeiten;
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

        private void BtnAddTechnik_Click(object sender, RoutedEventArgs e)
        {
            if (cmbKlasse.SelectedItem == null || aktuellerCharakter.Volk == null)
            {
                MessageBox.Show("Bitte zuerst Volk und Klasse auswählen.");
                return;
            }

            var klassenname = cmbKlasse.SelectedItem.ToString();
            var tupelListe = KlassenFaehigkeiten.VerfuegbareFaehigkeiten
                .GetValueOrDefault(klassenname, new());

            var verfügbare = tupelListe
                .Select(t => new Fähigkeit
                {
                    Name = t.Name,
                    Effekt = t.Effekt,
                    ChiKosten = t.ChiKosten
                }).ToList();


            var bereitsGewählt = aktiveFaehigkeiten.Select(f => f.Name).ToHashSet();
            var auswahl = verfügbare.Where(f => !bereitsGewählt.Contains(f.Name)).ToList();

            var dialog = new FähigkeitAuswahlDialog(auswahl);

            if (dialog.ShowDialog() == true && dialog.AusgewählteFähigkeiten.Any())
            {
                aktiveFaehigkeiten.AddRange(dialog.AusgewählteFähigkeiten);
                aktuellerCharakter.Fähigkeiten = new List<Fähigkeit>(aktiveFaehigkeiten);
                RenderFaehigkeiten();
            }
        }

        private void RenderFaehigkeiten()
        {
            lstAusgewaehlteTechniken.ItemsSource = null;
            lstAusgewaehlteTechniken.ItemsSource = aktiveFaehigkeiten;
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
            BtnAddTechnik.IsEnabled = bearbeitbar;
            BtnRemoveTechnik.IsEnabled = bearbeitbar;
            BtnSave.IsEnabled = bearbeitbar;

            // Optional: auch andere Eingaben oder Custom-Funktionen sperren
        }

        private void BtnRemoveTechnik_Click(object sender, RoutedEventArgs e)
        {
            if (lstAusgewaehlteTechniken.SelectedItem is Fähigkeit auswahl)
            {
                aktiveFaehigkeiten.Remove(auswahl);
                aktuellerCharakter.Fähigkeiten = new List<Fähigkeit>(aktiveFaehigkeiten);
                RenderFaehigkeiten();
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
            if (txtVolksBoniHinweis == null)
            {
                return;
            }

            if (aktiveVolksBoni == null)
            {
                return;
            }

            txtVolksBoniHinweis.Text = $"Ausgewählt: {aktiveVolksBoni.Count} / {maxBonusAuswahl}";
        }

        private void BtnRemoveVolksBoni_Click(object sender, RoutedEventArgs e)
        {
            if (lstAusgewaehlteVolksBoni.SelectedItem is BoniEintrag ausgewaehlterBonus)
            {
                aktiveVolksBoni.Remove(ausgewaehlterBonus);
                aktuellerCharakter.VolksBoni = aktiveVolksBoni.Select(b => b.Name).ToList();
                RenderVolksboni();
            }
            else
            {
                MessageBox.Show("Bitte wähle einen Bonus aus der Liste aus, den du entfernen möchtest.");
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






}
