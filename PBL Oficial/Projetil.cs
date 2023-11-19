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
            Gravidade = 9.8; // Valor da aceleração devido à gravidade (em m/s²).
            VelocidadeInicial = velocidadeInicial;
            AnguloDaTrajetoria = anguloDaTrajetoria * (Math.PI / 180.0); // Converte o ângulo para radianos.
            Vox = VelocidadeInicial * Calculadora.coseno(AnguloDaTrajetoria);//Calcula a velocidade no eixo x
            Voy = VelocidadeInicial * Calculadora.seno(AnguloDaTrajetoria);//Calcula a velocidade no eixo y
            AlturaMaximaProjetil = Math.Pow(Voy, 2) / (2 * Gravidade); // Calcula a altura máxima do projétil.
            AlturaInicial = 0; // Altura inicial é definida como zero.
        }

        /// Atualiza a velocidade inicial vertical do projétil.
        /// <param name="Vo">Nova velocidade inicial.</param>
        public void AtualizaVo(double Vo)
        {
            VelocidadeInicial = Vo;
            Voy = VelocidadeInicial * Calculadora.seno(AnguloDaTrajetoria);
        }
        /// Calcula e retorna a altura do projétil em um determinado tempo.
        /// <param name="tempo">Tempo decorrido desde o início.</param>
        /// <returns>Altura do projétil no tempo especificado.</returns>
        public double SetAltura(double tempo)
        {
            Altura = Voy * tempo - (Gravidade / 2) * Math.Pow(tempo, 2);
            return Altura;
        }
    }
}
