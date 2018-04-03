using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication2 {
    class Connection {
        public static SqlConnection addConnection() { 
            try {
                SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=bitcoin;Integrated Security=True");
                connection.Open();
                return connection;
            }
            catch (Exception e){
                MessageBox.Show("No se pudo conectar a la base de datos.");
                return null;
            }
        }

        public static void loadCountries(ComboBox cb) {
            SqlConnection con = addConnection();
            if (con != null) {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT pais FROM cliente;", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    cb.Items.Add(reader.GetString(0));
                }
                con.Close();
            }
        }

        public static void loadClients(DataGrid dataGrid)
        {
            SqlConnection con = addConnection();
            List<Client> list = new List<Client>();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM cliente;", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), Transaction.getClientBalance(reader.GetInt32(0))));
                }
            }

            dataGrid.ItemsSource = list;
        }
    }
}
