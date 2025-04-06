using NovaGaiaCharaktereditor.Klassen;
using System.Windows;

namespace NovaGaiaCharaktereditor
{
    public partial class FähigkeitAuswahlDialog : Window
    {
        private List<Fähigkeit> verfügbareFähigkeiten;

        public Fähigkeit SelectedFähigkeit { get; private set; }

        public FähigkeitAuswahlDialog(List<Fähigkeit> verfügbareFähigkeiten)
        {
            InitializeComponent();
            FähigkeitListBox.ItemsSource = verfügbareFähigkeiten;
            this.verfügbareFähigkeiten = verfügbareFähigkeiten;
        }

        private void BtnHinzufügen_Click(object sender, RoutedEventArgs e)
        {
            if (FähigkeitListBox.SelectedItem is Fähigkeit f)
            {
                SelectedFähigkeit = f;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Bitte wähle eine Fähigkeit aus.");
            }
        }
    }
}
