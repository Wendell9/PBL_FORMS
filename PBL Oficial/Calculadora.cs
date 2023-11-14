using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Oficial
{
    internal static class Calculadora
    {
        public static double fatorial(int n)
        {
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
        public static double coseno(double x)
        {
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
                    precisao_desejada_alcancada = true;
                }
                else
                {
                    k += 1;
                }
            }
            return f;
        }

        public static double seno(double x)
        {
            double precisao_desejada = Math.Pow(10, -20);

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

        public static double[] calculoVo(double angulo, Meteoro Meteoro1,Projetil Projetil1,bool baskara)
        {
            double senoAngulo;
            double cosenoAngulo;

            senoAngulo = Calculadora.seno((angulo * Math.PI) / 180);
            cosenoAngulo = Calculadora.coseno((angulo * Math.PI) / 180);

            double a;
            double b;
            double c;
            double delta;
            double Vo;

            a = Meteoro1.DistanciaDoCanhao * (senoAngulo / cosenoAngulo) - Meteoro1.AlturaInicial;
            b = (Meteoro1.DistanciaDoCanhao * Meteoro1.Vm) / cosenoAngulo;
            c = (-4.9 * Math.Pow(Meteoro1.DistanciaDoCanhao, 2)) / Math.Pow(cosenoAngulo, 2);

            delta = Math.Pow(b, 2) - 4 * a * c;
            if (baskara)
            {
                Vo = -1.0 * b - Math.Sqrt(delta);
                Vo /= 2.0 * a;
            }
            else
            {
                Vo = -1.0 * b + Math.Sqrt(delta);
                Vo /= 2.0 * a;
                Projetil1.AtualizaVo(Vo);
            }



            Projetil1 = new Projetil(Vo, angulo);

            double tempo;
            double alturaMet;
            double alturaProj;

            tempo = Meteoro1.DistanciaDoCanhao / (Vo * cosenoAngulo);
            double[] vetorResposta = new double[4];
            alturaMet = Meteoro1.SetAltura(tempo);
            alturaProj = Projetil1.SetAltura(tempo);
            vetorResposta[0] = alturaMet;
            vetorResposta[1] = alturaProj;
            vetorResposta[2] = tempo;
            vetorResposta[3] = Vo;
            return vetorResposta;
        }
    }
}
