using System.Collections.Generic;
using System.Linq;
using System.Windows;
using NovaGaiaCharaktereditor.Klassen;

namespace NovaGaiaCharaktereditor.HelpDialog
{
    public partial class FähigkeitAuswahlDialog : Window
    {
        public List<Fähigkeit> AusgewählteFähigkeiten { get; private set; } = new();

        public FähigkeitAuswahlDialog(List<Fähigkeit> verfügbareFähigkeiten)
        {
            InitializeComponent();
            lstFähigkeiten.ItemsSource = verfügbareFähigkeiten;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            AusgewählteFähigkeiten = lstFähigkeiten.SelectedItems.Cast<Fähigkeit>().ToList();
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
