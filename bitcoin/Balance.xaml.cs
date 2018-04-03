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
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Lógica de interacción para Balance.xaml
    /// </summary>
    public partial class Balance : Window
    {
        Window parent;
        public Balance(Window parent)
        {
            this.parent = parent;
            InitializeComponent();
            Connection.loadClients(dataGrid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            parent.Show();
        }
    }
}
