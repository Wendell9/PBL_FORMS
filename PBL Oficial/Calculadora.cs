using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PBL_Oficial
{
    /// Classe estática Calculadora com métodos para cálculos trigonométricos e de lançamento do projétil.
    internal static class Calculadora
    {
        /// Calcula o fatorial de um número inteiro.
        public static double fatorial(int n)
        {
            try
            {
                // Verifica se o número é maior que zero para calcular o fatorial.
                int valorFatorial = 1;
                if (n > 0)
                {
                    for (int i = n; i > 0; i--)
                    {
                        valorFatorial *= i;
                    }
                }

                return valorFatorial;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// Calcula o cosseno de um ângulo utilizando a Série de Taylor.
        public static double coseno(double x)
        {
            try
            {
                //o double precisa desejada é a precisão desejada para o coseno, uma vez que a série de 
                //Taylor não retorna um valor exato
                double precisao_desejada = Math.Pow(10, -20);

                bool precisao_desejada_alcancada = false;

                int k;
                k = 0;

                double f = 0;

                double r;

                while (!precisao_desejada_alcancada)
                {
                    if (k == 0)
                    {
                        f += 1;
                    }
                    else if (k >= 1 && k % 2 == 0 && k % 4 != 0)
                    {
                        f += (-1) * Math.Pow(x, k) / Calculadora.fatorial(k);
                    }
                    else if (k >= 1 && k % 4 == 0)
                    {
                        f += (Math.Pow(x, k)) / Calculadora.fatorial(k);
                    }

                    r = (Math.Pow(Math.Abs(x), (k + 1)) / Calculadora.fatorial(k + 1));

                    if (r <= precisao_desejada)
                    {
                        //Caso a precisão desejada ~tenha sido alcançada, a variavel booleana é definida como
                        //verdadeira e o laço de repetição se encerrará
                        precisao_desejada_alcancada = true;
                    }
                    else
                    {
                        //caso a precisão não tenha sido alcançada, o laço continua e k é incrementado mais um
                        k += 1;
                    }
                }
                return f;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// Calcula o seno de um ângulo utilizando a Série de Taylor.
        public static double seno(double x)
        {
            try
            {
                double precisao_desejada = Math.Pow(10, -20);
                //possui os mesmos principios do código do coseno, só que levando em consideração
                //a série de Taylor do seno
                //no caso é recebido um valor double x, que é o angulo em graus
                bool precisao_desejada_alcancada = false;

                int k;
                k = 0;

                double f = 0;

                double r;

                int i = -1;

                while (!precisao_desejada_alcancada)
                {
                    if (k == 1)
                    {
                        f += x;
                    }
                    else if (k % 2 != 0)
                    {
                        f += i * Math.Pow(x, k) / Calculadora.fatorial(k);
                        i *= -1;
                    }

                    r = (1 / Calculadora.fatorial(k + 1)) * Math.Pow(Math.Abs(x), k + 1);

                    if (r <= precisao_desejada)
                    {
                        precisao_desejada_alcancada = true;
                    }
                    else
                    {
                        k += 1;
                    }
                }
                return f;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// Calcula a velocidade inicial (Vo),tempo de impacto, altura do meteoro e do projétil no tempo de impacto
        public static double[] calculoVo(double angulo, Meteoro Meteoro1, Projetil Projetil1, bool baskara)
        {
            try
            {
                double senoAngulo;
                double cosenoAngulo;
                //aqui é determinado o seno e o coseno do angulo. O seno que foi recebido em graus é convertido
                //para radianos pela multiplicação por PI/180
                senoAngulo = Calculadora.seno((angulo * Math.PI) / 180);
                cosenoAngulo = Calculadora.coseno((angulo * Math.PI) / 180);

                double a;
                double b;
                double c;
                double delta;
                double Vo;
                //aqui são declaradas as variaveis para se calcular o baskara

                a = Meteoro1.DistanciaDoCanhao * (senoAngulo / cosenoAngulo) - Meteoro1.AlturaInicial;
                b = (Meteoro1.DistanciaDoCanhao * Meteoro1.Vm) / cosenoAngulo;
                c = (-4.9 * Math.Pow(Meteoro1.DistanciaDoCanhao, 2)) / Math.Pow(cosenoAngulo, 2);

                delta = Math.Pow(b, 2) - 4 * a * c;
                //aqui é calculado o valor do delta
                if (baskara)
                {
                    //caso baskara seja verdadeiro, se leva em conta delta subtraindo
                    Vo = -1.0 * b - Math.Sqrt(delta);
                    Vo /= 2.0 * a;
                }
                else
                {
                    //caso baskara seja falso, se leva em conta delta somando
                    Vo = -1.0 * b + Math.Sqrt(delta);
                    Vo /= 2.0 * a;
                    Projetil1.AtualizaVo(Vo);
                    //Aqui o projetil chama um método que atualiza a velocidade inicial desse e recalcula Voy
                }



                Projetil1 = new Projetil(Vo, angulo);
                //Aqui é instanciado um novo projetil, baseado no Vo de baskara e no angulo fornecido
                double tempo;
                double alturaMet;
                double alturaProj;
                //Aqui é calculado o tempo de impacto baseado no tempo que o projetil demora para atindir a
                //distância do meteoro
                tempo = Meteoro1.DistanciaDoCanhao / (Vo * cosenoAngulo);
                double[] vetorResposta = new double[4];
                alturaMet = Meteoro1.SetAltura(tempo);
                alturaProj = Projetil1.SetAltura(tempo);
                //Aqui são atribuidos os valores mencionados anteriormente em um vetor resposta
                vetorResposta[0] = alturaMet;
                vetorResposta[1] = alturaProj;
                vetorResposta[2] = tempo;
                vetorResposta[3] = Vo;
                return vetorResposta;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
