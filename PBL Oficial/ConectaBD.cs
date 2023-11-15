using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PBL_Oficial
{
    public static class ConectaBD
    {
        public static void conecta(int canhaoID, int MeteoroID, double angulo, double velocidade, double tempo)
        {
            string connectionString = "Data Source=DESKTOP-UOHE1VE\\SQLSERVER2022;Initial Catalog=pbl_bd;Integrated Security=True;User ID=sa;Password=123456";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = $"sp_InserirAcerto @canhaoID,@meteoroID,@angulo,@velocidade,@tempo";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    //adicionando parametros
                    command.Parameters.AddWithValue("@canhaoID", canhaoID);
                    command.Parameters.AddWithValue("@meteoroID", MeteoroID);
                    command.Parameters.AddWithValue("@angulo", angulo);
                    command.Parameters.AddWithValue("@velocidade", velocidade);
                    command.Parameters.AddWithValue("@tempo", tempo);

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
