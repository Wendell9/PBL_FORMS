using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Oficial
{
    internal class Meteoro
    {
        public double DistanciaDoCanhao;
        public double AlturaInicial;
        public double Vm;
        public double Altura;

        public Meteoro(double distancia,double altura)
        {
            DistanciaDoCanhao = distancia;
            AlturaInicial = altura;
            Vm = 50;
        }

        public double SetAltura(double tempo)
        {
            Altura = AlturaInicial - Vm * tempo;
            return Altura;
        }
    }
}
