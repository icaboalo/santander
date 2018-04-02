using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2 {

    class Client {

        int idClient;
        String name;
        String lastname;
        String country;

        public Client(int idClient, String name, String lastname, String country) {
            this.idClient = idClient;
            this.name = name;
            this.lastname = lastname;
            this.country = country;
        }

        public static List<Client> getClientsByCountry(String country) {
            List<Client> list = new List<Client>();
            SqlConnection con = Connection.addConnection();

            if (con != null) {
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM cliente WHERE pais = '{0}'", country), con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    list.Add(new Client(reader.GetInt16(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
            }

            return list;
        }

        
    }
}
