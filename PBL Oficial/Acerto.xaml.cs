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
    /// Lógica interna para Acerto.xaml
    /// </summary>
    public partial class Acerto : Window
    {
        Animacao animacao1;
        public Acerto(Projetil projetil,double alturaImpacto,double tempo,Animacao animacao,double distancia,double angulo,double alturaMeteoro)
        {
            try
            {
            InitializeComponent();
            //O objetivo dessa parte é demonstrar para o usuario os dados de acerto, sendo eles velocidade inicial e altura de impacto
            VelocidadeInicial.Content = $"Velocidade Inicial: {projetil.VelocidadeInicial} m/s";
            Altura_intercepta.Content = $"O meteoro é interceptado na altura: {alturaImpacto}m";
            animacao1 = animacao;
            //Aqui é avaliado se o movimento do projetil está em fase ascendente ou descendente. É calculado o tempo
            //para se atingr a altura máxima do projetil na variavel "tempoPontoMaximo", caso o tempo de impacto do
            //tempo seja menor que tempoPontoMaximo , o movimento é ascendente. Caso contrário é descendente. 
            double tempoPontoMaximo;
            //para descobir tempoPontoMaximo é dividido a altura maxima pela velocidade do projetil em voy
            tempoPontoMaximo = projetil.AlturaMaximaProjetil / projetil.Voy;
            if (tempo<tempoPontoMaximo)
            {
                Ponto_Do_Movimeto.Content = $"O movimento do projétil no instante {tempo.ToString("F2")} é ascendente";
            }
            else
            {
                Ponto_Do_Movimeto.Content = $"O movimento do projétil no instante {tempo.ToString("F2")} é descendente";
            }
            int idMeteoro;
            int idCanhao;
            //aqui foi instanciado um switch case para traduzir as alturas e distâncias do meteoro para seus respectivos ids
            //no banco de dados.
            switch  (alturaMeteoro)
            {
                case 4000:
                    idMeteoro = 1; break;
                case 3000:
                    idMeteoro= 2; break;
                case 2000:
                    idMeteoro = 3;break;
                default:
                    idMeteoro = 4; break;
            }

            switch (distancia)
            {
                case 1000.0:
                    idCanhao = 1; break;
                case 750.0:
                    idCanhao = 2; break;
                case 500.0:
                    idCanhao = 3; break;
                default:
                    idCanhao = 4; break;
            }
            //Aqui é chamado o comando inseriracerto para inserir os dados na tabela acerto

            ComandosBD.InserirAcerto(idCanhao, idMeteoro,angulo,projetil.VelocidadeInicial,tempo);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inicio janelaprincipal = new Inicio();
            janelaprincipal.Show();
            //Caso o usuario opte pela opção tentar novamente, é instanciada uma janela principal,
            //de modo que a janela acerto desaparece
            this.Close();
            animacao1.Close();
        }
    }
}
