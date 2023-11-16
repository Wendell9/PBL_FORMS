using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PBL_Oficial.ConexaoBD
{
    public static class ComandosBD
    {
        public static void InserirAcerto(int canhaoID, int MeteoroID, double angulo, double velocidade, double tempo)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.Conectar();


            if (con.State == System.Data.ConnectionState.Open)
            {
                string queryy = $"sp_InserirAcerto @canhaoID,@meteoroID,@angulo,@velocidade,@tempo";

                using (SqlCommand command = new SqlCommand(queryy, con))
                {
                    //adicionando parametros
                    command.Parameters.AddWithValue("@canhaoID", canhaoID);
                    command.Parameters.AddWithValue("@meteoroID", MeteoroID);
                    command.Parameters.AddWithValue("@angulo", angulo);
                    command.Parameters.AddWithValue("@velocidade", velocidade);
                    command.Parameters.AddWithValue("@tempo", tempo);

                    command.ExecuteNonQuery();
                }
            }
            con = conexao.Desconectar();

            string query = $"sp_InserirAcerto @canhaoID,@meteoroID,@angulo,@velocidade,@tempo";

        }
        public static void LimparDados()
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.Conectar();


            if (con.State == System.Data.ConnectionState.Open)
            {
                string queryy = $"exec sp_limparDados";

                using (SqlCommand command = new SqlCommand(queryy, con))
                {
                    command.ExecuteNonQuery();
                }
            }
            con = conexao.Desconectar();
        }

        public static DataTable select()
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.Conectar();
            DataTable tabela = new DataTable();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string queryy = $"exec sp_consulta";

                using (SqlCommand command = new SqlCommand(queryy, con))
                {

                    SqlDataAdapter data = new SqlDataAdapter(command);

                    data.Fill(tabela);
                }
            }
            con.Close();
            return tabela;


        }

    }
}
