using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Oficial.ConexaoBD
{
        public class Conexao
        {
            SqlConnection con = new SqlConnection();
            public Conexao()
            {
                con.ConnectionString = "Data Source=DESKTOP-UOHE1VE\\SQLSERVER2022;Initial Catalog=pbl_bd;Integrated Security=True;User ID=sa;Password=123456";
            }

            public SqlConnection Conectar()
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }

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

