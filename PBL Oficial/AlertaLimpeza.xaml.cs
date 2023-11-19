using PBL_Oficial.ConexaoBD;
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
using System.Windows.Shapes;

namespace PBL_Oficial
{
    /// <summary>
    /// Lógica interna para AlertaLimpeza.xaml
    /// </summary>
    public partial class AlertaLimpeza : Window
    {
        public AlertaLimpeza()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Caso o usuario opte por sim, isso irá acionar o comando limparDados que irá limpar os dados de acerto
            //da tabela Acertos no Banco de dados
            ComandosBD.LimparDados();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Caso se opte por não, é instanciada uma janela consultar para retornar o usuario a janela anterior
            Consultar consultar = new Consultar();
            //Essa janela é fechada
            this.Close();
        }
    }
}
