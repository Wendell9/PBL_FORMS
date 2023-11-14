using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Oficial
{
    public class Projetil
    {
        public double VelocidadeInicial { get; private set; }
        public double AnguloDaTrajetoria { get; private set; }
        public double AlturaMaximaProjetil { get; private set; }
        public double Vox { get; private set; }
        public double Voy { get; private set; }
        public double Gravidade { get; private set; }
        public double AlturaInicial { get; private set; }
        public double Altura { get; private set; }

        public Projetil(double velocidadeInicial, double anguloDaTrajetoria)
        {
            Gravidade = 9.8;
            VelocidadeInicial = velocidadeInicial;
            AnguloDaTrajetoria = anguloDaTrajetoria * (Math.PI / 180.0);
            Vox = VelocidadeInicial * Calculadora.coseno(AnguloDaTrajetoria);
            Voy = VelocidadeInicial * Calculadora.seno(AnguloDaTrajetoria);
            AlturaMaximaProjetil = Math.Pow(Voy, 2) / (2 * Gravidade);
            AlturaInicial = 0;
        }

        public void AtualizaVo(double Vo)
        {
            VelocidadeInicial = Vo;
            Voy = VelocidadeInicial * Calculadora.seno(AnguloDaTrajetoria);
        }
        public double SetAltura(double tempo)
        {
            Altura = Voy * tempo - (Gravidade / 2) * Math.Pow(tempo, 2);
            return Altura;
        }
    }
}
