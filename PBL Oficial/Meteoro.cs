using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Oficial
{
    /// Classe que representa um meteoro no contexto do programa.
    internal class Meteoro
    {
        public double DistanciaDoCanhao;
        public double AlturaInicial;
        public double Vm;
        public double Altura;

        /// Construtor da classe Meteoro.
        /// <param name="distancia">Distância do meteoro ao canhão.</param>
        /// <param name="altura">Altura inicial do meteoro.</param>

        public Meteoro(double distancia,double altura)
        {
            //Aqui são determinadas as caracteristicas do meteoro, como alturainicial,distanciado canhao e velocidade
            DistanciaDoCanhao = distancia;
            AlturaInicial = altura;
            Vm = 50;///A velocidade do meteoro é constante independente das escolhas do usuario
        }

        /// Atualiza a altura do meteoro com base no tempo passado.
        /// <param name="tempo">Tempo decorrido desde o início.</param>
        /// <returns>Altura atualizada do meteoro.</returns>
        public double SetAltura(double tempo)
        {
            Altura = AlturaInicial - Vm * tempo; // Fórmula para calcular a altura em função do tempo.
            return Altura;
        }
    }
}
