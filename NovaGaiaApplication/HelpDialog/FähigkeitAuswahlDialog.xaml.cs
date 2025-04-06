using System.Collections.Generic;
using System.Windows;

namespace NovaGaiaCharaktereditor
{
    public partial class FähigkeitAuswahlDialog : Window
    {
        public Fähigkeit SelectedFähigkeit { get; private set; }

        public FähigkeitAuswahlDialog(List<Fähigkeit> verfügbareFähigkeiten)
        {
            InitializeComponent();
            FähigkeitListBox.ItemsSource = verfügbareFähigkeiten;
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
