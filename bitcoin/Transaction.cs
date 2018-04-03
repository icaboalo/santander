using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication2
{
    class Transaction
    {

        int idTransaction;
        float balance;
        int idClient;

        public Transaction(float balance, Int32 idClient)
        {
            this.balance = balance;
            this.idClient = idClient;
        }

        public int saveTransaction(Int32 clientA)
        {
            if (this.balance > getClientBalance(clientA))
            {
                MessageBox.Show("No se pudo crear la transacción debido a que el saldo es insuficiente.");
                return 0;
            }

            int res = 0;
            SqlConnection con = Connection.addConnection();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO transaccion VALUES((SELECT TOP 1 idTran + 1 FROM transaccion ORDER BY idTran DESC), {0}, {1}); INSERT INTO transaccion VALUES((SELECT TOP 1 idTran + 1 FROM transaccion ORDER BY idTran DESC), {2}, {3});", this.balance, this.idClient, this.balance*-1, clientA), con);
                res = cmd.ExecuteNonQuery();
            }
            con.Close();
            return res;
        }

        public static double getClientBalance(Int32 clientA)
        {
            double balance = 0;
            SqlConnection con = Connection.addConnection();
            if (con != null)
            {
                SqlCommand cmd = new SqlCommand(String.Format("SELECT CONVERT(float, SUM(saldo)) FROM transaccion WHERE idCliente = {0};", clientA), con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   balance = reader.GetDouble(0);
                }
            }
            con.Close();
            return balance;
        }
    }
}
