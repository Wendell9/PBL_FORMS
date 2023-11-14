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
    /// Lógica interna para Angulo.xaml
    /// </summary>
    public partial class Angulo : Window
    {
        private Meteoro Meteoro1;
        public Projetil Projetil1;
        public Angulo(double AlturaMeteoro, double Distancia)
        {
            InitializeComponent();
            Meteoro1 = new Meteoro(Distancia, AlturaMeteoro);
            string velocidade = $"A velocidade do meteoro é igual a {Meteoro1.Vm}";
            Label_Velocidade.Content = velocidade;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double angulo = double.Parse(TEXTBOXANGULO.Text);

            double[] vetorResposta = new double[3];
            Projetil1 = new Projetil(angulo, 0);
            vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, true);

            double alturaMet;
            double alturaProj;
            double tempo;

            alturaMet = vetorResposta[0];
            alturaProj = vetorResposta[1];
            tempo = vetorResposta[2];
            double vo = vetorResposta[3];
            int contaerros = 0;

            if (Math.Abs(alturaMet - alturaProj) < 1 && tempo > 0 && alturaMet > 0)
            {
                Projetil1 = new Projetil(angulo, vo);
                MessageBox.Show($"O alvo foi acertado no ponto {alturaProj}, no instante {tempo} com velocidade inicial igual a {vo}");
                Animacao animacao = new Animacao(tempo, Meteoro1.AlturaInicial, alturaMet, Meteoro1.DistanciaDoCanhao, vo, angulo);
                animacao.Show();
                this.Close();
            }
            else
            {
                contaerros += 1;
            }
            vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, false);

            alturaMet = vetorResposta[0];
            alturaProj = vetorResposta[1];
            tempo = vetorResposta[2];
            vo = vetorResposta[3];

            if (Math.Abs(alturaMet - alturaProj) < 1 && tempo > 0 && alturaMet > 0)
            {
                MessageBox.Show($"O alvo foi acertado no ponto {alturaProj}, no instante {tempo} com velocidade inicial igual a {vo}");
                Animacao animacao = new Animacao(tempo, Meteoro1.AlturaInicial, alturaMet, Meteoro1.DistanciaDoCanhao, vo, angulo);
                animacao.Show();
                this.Close();
            }
            else
            {
                contaerros += 1;
            }
            if (contaerros == 2)
            {
                int[] rangeDoAngulo = new int[2];

                for (int i = 1; i < 90; i++)
                {
                    angulo = i;
                    Projetil1 = new Projetil(angulo, 0);
                    vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, true);


                    alturaMet = vetorResposta[0];
                    alturaProj = vetorResposta[1];
                    tempo = vetorResposta[2];
                    contaerros = 0;

                    if (Math.Abs(alturaMet - alturaProj) < 1 && tempo > 0 && alturaMet > 0)
                    {
                        contaerros++;
                    }
                    vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, false);

                    alturaMet = vetorResposta[0];
                    alturaProj = vetorResposta[1];
                    tempo = vetorResposta[2];

                    if (Math.Abs(alturaMet - alturaProj) < 1 && tempo > 0 && alturaMet > 0)
                    {
                        contaerros++;
                    }

                    if (contaerros > 0)
                    {
                        rangeDoAngulo[0] = i;
                        break;
                    }
                }
                for (int i = rangeDoAngulo[0] + 1; i < 90; i++)
                {
                    angulo = i;
                    Projetil1 = new Projetil(angulo, 0);
                    vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, true);
                    contaerros = 0;

                    alturaMet = vetorResposta[0];
                    alturaProj = vetorResposta[1];
                    tempo = vetorResposta[2];
                    vo = vetorResposta[3];
                    contaerros = 0;

                    if (Math.Abs(alturaMet - alturaProj) >= 1 || tempo < 0 || alturaMet < 0)
                    {
                        contaerros++;
                    }

                    vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, false);

                    alturaMet = vetorResposta[0];
                    alturaProj = vetorResposta[1];
                    tempo = vetorResposta[2];
                    vo = vetorResposta[3];
                    if (Math.Abs(alturaMet - alturaProj) >= 1 || tempo < 0 || alturaMet < 0)
                    {
                        contaerros++;
                    }

                    if (contaerros == 2)
                    {
                        rangeDoAngulo[1] = i-1;
                    }
                    else if (i == 89)
                    {
                        rangeDoAngulo[1] = 89;
                        break;
                    }
                }
                MessageBox.Show($"Para acertar o alvo o ângulo deve estar entre {rangeDoAngulo[0]}° e {rangeDoAngulo[1]}");
            }

        }
    }
}

