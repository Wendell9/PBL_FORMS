using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Oficial.ConexaoBD
{
    /// Classe responsável por gerenciar a conexão com o banco de dados.
    public class Conexao
    {

        SqlConnection con = new SqlConnection();
        /// Construtor da classe Conexao. Define a string de conexão com o banco de dados.
        public Conexao()
        {
            con.ConnectionString = "Data Source=DESKTOP-UOHE1VE\\SQLSERVER2022;Initial Catalog=pbl_bb;Integrated Security=True;User ID=sa;Password=123456";
        }

        /// Estabelece a conexão com o banco de dados, se estiver fechada.
        /// Objeto SqlConnection representando a conexão.
        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        /// Fecha a conexão com o banco de dados, se estiver aberta.
        /// Objeto SqlConnection representando a conexão.
        public SqlConnection Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }
    }
}

