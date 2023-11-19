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
        /// Insere um registro de acerto no banco de dados.
        public static void InserirAcerto(int canhaoID, int MeteoroID, double angulo, double velocidade, double tempo)
        {
            //É instanciada uma classe conexão. Dentro dessa classe será possivel chamar métodos para 
            //abrir e fechar a conexão
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.Conectar();


            if (con.State == System.Data.ConnectionState.Open)
            {
                //caso o estado de conexão esteja aberto, é declarado o comando para executar uma procedure
                //dentro do banco de dados
                string queryy = $"exec sp_InserirAcerto @canhaoID,@meteoroID,@angulo,@velocidade,@tempo";

                using (SqlCommand command = new SqlCommand(queryy, con))
                {
                //aqui é utilizado o command que recebe como parâmetros o comando instanciado e 
                    //a conexão com o banco de dados
                    //adicionando parametros
                    command.Parameters.AddWithValue("@canhaoID", canhaoID);
                    command.Parameters.AddWithValue("@meteoroID", MeteoroID);
                    command.Parameters.AddWithValue("@angulo", angulo);
                    command.Parameters.AddWithValue("@velocidade", velocidade);
                    command.Parameters.AddWithValue("@tempo", tempo);

                    command.ExecuteNonQuery();
                    //Aqui o comando é executado
                }
            }
            con =conexao.Desconectar();
            //A conexão com o banco de dados é fechada pelo método Desconectar dentro da classe conexão
        }

        /// <summary>
        /// Limpa os dados da tabela no banco de dados.
        /// </summary>
        public static void LimparDados()
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.Conectar();


            if (con.State == System.Data.ConnectionState.Open)
            {
                //caso o estado de conexão esteja aberto, é declarado o comando para executar uma procedure
                //dentro do banco de dados
                string queryy = $"exec sp_limparDados";

                using (SqlCommand command = new SqlCommand(queryy, con))
                {
                    command.ExecuteNonQuery();
                    //aqui é utilizado o command que recebe como parâmetros o comando instanciado e 
                    //a conexão com o banco de dados
                    //adicionando parametros
                }
            }
            con = conexao.Desconectar();
            //A conexão com o banco de dados é fechada pelo método Desconectar dentro da classe conexão
        }

        /// <summary>
        /// Realiza uma consulta no banco de dados e retorna os resultados em uma tabela.
        /// </summary>
        /// <returns>DataTable contendo os resultados da consulta.</returns>
        public static DataTable select()
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.Conectar();
            DataTable tabela = new DataTable();
            if (con.State == System.Data.ConnectionState.Open)
            {
                //caso o estado de conexão esteja aberto, é declarado o comando para executar uma procedure
                //dentro do banco de dados
                string queryy = $"exec sp_consulta";

                using (SqlCommand command = new SqlCommand(queryy, con))
                {

                    SqlDataAdapter data = new SqlDataAdapter(command);
                    //Aqui os dados pegos pela procedure são armazenados em data

                    data.Fill(tabela);
                    //Aqui ess data preenche a DataTable tabela
                }
            }
            con.Close();
            //A conexão é fechada
            return tabela;
            //Retorna a tabela preenchida com os dados do select


        }

    }
}
