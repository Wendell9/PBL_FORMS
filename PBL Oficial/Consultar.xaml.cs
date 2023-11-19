using PBL_Oficial.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace PBL_Oficial
{
    /// <summary>
    /// Lógica interna para Consultar.xaml
    /// </summary>
    public partial class Consultar : Window
    {
        public Consultar()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Recebe um DataTable por meio do método ComandosBD.select(). Essa tabela em questão
            //demonstra os testes bem sucedidos adicionados no banco de dados
            DataTable tabela = ComandosBD.select();
            dataGrid.ItemsSource = tabela.DefaultView;

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //É um botão de voltar que instancia uma janela inicio, a mostra e fecha a janela atual
            Inicio i = new Inicio();
            i.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Instancia a janela alertaLimpeza e a mostra
            AlertaLimpeza a=new AlertaLimpeza();
            a.Show();
        }
    }
}
