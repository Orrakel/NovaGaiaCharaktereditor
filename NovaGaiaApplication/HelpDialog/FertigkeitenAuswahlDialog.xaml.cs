using System.Collections.Generic;
using System.Linq;
using System.Windows;
using NovaGaiaCharaktereditor.Data;

namespace NovaGaiaCharaktereditor.Dialoge
{
    public partial class FertigkeitenAuswahlDialog : Window
    {
        public List<Fertigkeit> AusgewaehlteFertigkeiten { get; private set; } = new();

        private int maxAnzahl;

        public FertigkeitenAuswahlDialog(List<Fertigkeit> verfügbare, int maxAnzahl = 4)
        {
            InitializeComponent();
            this.maxAnzahl = maxAnzahl;
            lstFertigkeiten.ItemsSource = verfügbare;
            txtHinweis.Text = $"Maximale Auswahl: {maxAnzahl}";
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (lstFertigkeiten.SelectedItems.Count > maxAnzahl)
            {
                MessageBox.Show($"Bitte wähle höchstens {maxAnzahl} Fertigkeiten aus.");
                return;
            }

            AusgewaehlteFertigkeiten = lstFertigkeiten.SelectedItems.Cast<Fertigkeit>().ToList();
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
