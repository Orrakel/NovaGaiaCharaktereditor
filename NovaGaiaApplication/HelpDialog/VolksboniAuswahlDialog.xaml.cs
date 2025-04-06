using System.Collections.Generic;
using System.Linq;
using System.Windows;
using NovaGaiaCharaktereditor.Data;
using NovaGaiaCharaktereditor.Klassen;

namespace NovaGaiaCharaktereditor.HelpDialog
{
    public partial class VolksboniAuswahlDialog : Window
    {
        public List<BoniEintrag> AusgewählteBoni { get; private set; } = new();

        private int maxAnzahl;

        public VolksboniAuswahlDialog(List<BoniEintrag> verfügbareBoni, int maxAnzahl)
        {
            InitializeComponent();
            this.maxAnzahl = maxAnzahl;
            lstBoni.ItemsSource = verfügbareBoni;
            txtAuswahlHinweis.Text = $"Maximale Auswahl: {maxAnzahl}";
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoni.SelectedItems.Count > maxAnzahl)
            {
                MessageBox.Show($"Bitte wähle maximal {maxAnzahl} Boni aus.");
                return;
            }

            AusgewählteBoni = lstBoni.SelectedItems.Cast<BoniEintrag>().ToList();
            DialogResult = true;
            Close();
        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
