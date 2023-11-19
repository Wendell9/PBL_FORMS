using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PBL_Oficial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// Manipula o clique no primeiro botão.
        /// Cria uma instância de Canhao com um valor de 4000.0, valor do botão, e exibe a janela Canhao.
        /// Fecha a janela atual.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
         Canhao canhao=new Canhao(4000.0);
         canhao.Show();
         this.Close();
        }
        /// Manipula o clique no segundo botão.
        /// Cria uma instância de Canhao com um valor de 3000.0 e exibe a janela Canhao.
        /// Fecha a janela atual.
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Canhao canhao = new Canhao(3000.0);
            canhao.Show();
            this.Close();
        }
        /// Manipula o clique no terceiro botão.
        /// Cria uma instância de Canhao com um valor de 2000.0 e exibe a janela Canhao.
        /// Fecha a janela atual.
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Canhao canhao = new Canhao(2000.0);
            canhao.Show();
            this.Close();
        }
        /// Manipula o clique no quarto botão.
        /// Cria uma instância de Canhao com um valor de 1000.0 e exibe a janela Canhao.
        /// Fecha a janela atual.
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Canhao canhao = new Canhao(1000.0);
            canhao.Show();
            this.Close();
        }
        /// Manipula o clique no quinto botão.
        /// Cria uma instância de Inicio e exibe a janela Inicio.
        /// Fecha a janela atual.
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show(); 
            this.Close();
        }
    }
}
