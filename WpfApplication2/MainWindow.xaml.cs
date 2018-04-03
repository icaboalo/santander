using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2 {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Connection.loadCountries(cbCountries);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Cliente a: " + (cbA.SelectedValue as Client).idClient + " cliente b: " + (cbB.SelectedValue as Client).idClient);
            Transaction transaction = new Transaction(float.Parse(tbBalance.Text), (cbB.SelectedValue as Client).idClient);
            if (transaction.saveTransaction((cbA.SelectedValue as Client).idClient) > 0)
            {
                MessageBox.Show("Transferencia enviada!");
            } else
            {

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            List<Client> list = Client.getClientsByCountry(cbCountries.SelectedValue.ToString());
            cbA.ItemsSource = list;
            cbB.ItemsSource = list;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Balance(this).Show();
        }
    }
}
