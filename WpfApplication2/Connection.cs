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
            SqlConnection con = new SqlConnection("");

            try {
                con.Open();
            } catch {
                MessageBox.Show("No se pudo conectar...");
                con = null;
            }

            return con;
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
    }
}
