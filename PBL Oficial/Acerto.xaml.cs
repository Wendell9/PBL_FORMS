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
        public Acerto(Projetil projetil,double altura,double tempo,Animacao animacao,double distancia,double angulo)
        {
            InitializeComponent();
            VelocidadeInicial.Content = $"Velocidade Inicial: {projetil.VelocidadeInicial}";
            Altura_intercepta.Content = $"O meteoro é interceptado na altura: {altura}";
            animacao1 = animacao;
            if (altura<projetil.AlturaMaximaProjetil && projetil.Vox*tempo<distancia)
            {
                Ponto_Do_Movimeto.Content = $"O movimento do projétil no instante {tempo.ToString("F2")} é ascendente";
            }
            else
            {
                Ponto_Do_Movimeto.Content = $"O movimento do projétil no instante {tempo.ToString("F2")} é descendente";
            }
            int idMeteoro;
            int idCanhao;
            switch  (altura)
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

            ComandosBD.InserirAcerto(idCanhao, idMeteoro,angulo,projetil.VelocidadeInicial,tempo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inicio janelaprincipal = new Inicio();
            janelaprincipal.Show();
            this.Close();
            animacao1.Close();
        }
    }
}
