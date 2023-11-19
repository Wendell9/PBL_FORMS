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

        /// Construtor da classe Angulo.
        /// Inicializa a janela Angulo com um Meteoro e exibe sua velocidade inicial.
        public Angulo(double AlturaMeteoro, double Distancia)
        {
            InitializeComponent();
            Meteoro1 = new Meteoro(Distancia, AlturaMeteoro);
            string velocidade = $"A velocidade do meteoro é igual a {Meteoro1.Vm}m/s";
            Label_Velocidade.Content = velocidade;
        }
        /// Manipula a alteração de texto no TextBox.
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /// Manipula o clique no segundo botão.
        /// Realiza cálculos com o ângulo fornecido e exibe a animação se os parâmetros estiverem corretos.
        /// Caso contrário, realiza uma verificação para encontrar um intervalo válido de ângulos.
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double angulo = double.Parse(TEXTBOXANGULO.Text);

            double[] vetorResposta = new double[3];
            Projetil1 = new Projetil(angulo, 0);
            //o vetor resposta receberá os resultados trazidos do método calculoVo dentro da classe calculadora
            //sendo essas respostas a altura do meteoro e do projetil no tempo de impacto, o tempo de impacto e a velocidade inicial em questão

            vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, true);

            double alturaMet;
            double alturaProj;
            double tempo;

            alturaMet = vetorResposta[0];
            alturaProj = vetorResposta[1];
            tempo = vetorResposta[2];
            double vo = vetorResposta[3];
            int contaerros = 0;
            //aqui é utilizado um if para determinar se o projetil atingiu o meteoro. As condições para isso são que 
            //a altura do meteoro menos a altura do projetil seja menos que 1, sendo 1 a margem de erro, que o tempo seja positivo
            //e que a altura do meteoro no tempo de impacto seja posistiva
            if (Math.Abs(alturaMet - alturaProj) < 1 && tempo > 0 && alturaMet > 0)
            {
                //Caso esteja correto, uma classe animação é instanciada com o intuito de demonstrar a animação do projetil
                //e do meteoro utilizando essa velocidade inicial
                Projetil1 = new Projetil(angulo, vo);
                Animacao animacao = new Animacao(tempo, Meteoro1.AlturaInicial, alturaMet, Meteoro1.DistanciaDoCanhao, vo, angulo);
                animacao.Show();
                this.Close();
            }
            else
            {
                //Caso não atenda as condições do if, o contador de erros soma mais um. Pelo fato de utilizarmos baskara para 
                //solucionar o problema, há duas respostas possiveis para Vo(velocidade inicial). Caso as duas respostas não
                //atendam os requisito para serem consideradas validas significa que para aquele ângulo em questão, não há resultados
                //válidos. Desse modo, se o contaerros for igual a 2, o porgrama calcula o range de angulos validos. 
                contaerros += 1;
            }
            //Recalcula o vetor resposta. Ao enviar um false, o delta é considerado positivo, produzindo um resultado diferente.
            vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, false);

            alturaMet = vetorResposta[0];
            alturaProj = vetorResposta[1];
            tempo = vetorResposta[2];
            vo = vetorResposta[3];

            //testa o vo com a nova velocidade e vê se o projetil interceptará o meteoro dessa vez
            if (Math.Abs(alturaMet - alturaProj) < 1 && tempo > 0 && alturaMet > 0)
            {
                Animacao animacao = new Animacao(tempo, Meteoro1.AlturaInicial, alturaMet, Meteoro1.DistanciaDoCanhao, vo, angulo);
                animacao.Show();
                this.Close();
            }
            else
            {
                contaerros += 1;
            }
            //caso o contaerros for igual a 2 será calculado o range do Ângulo de acerto para a distância e a altura
            //escolhidas
            if (contaerros == 2)
            {
                //é criado um vetor para armazenar o range do Ângulo
                int[] rangeDoAngulo = new int[2];
                //aqui é criado um for que vai de 1 a 90(grau máximo possivel de acerto) e cria velocidades iniciais novas
                //para diversos ângulos
                for (int i = 1; i < 90; i++)
                {
                    angulo = i;
                    Projetil1 = new Projetil(angulo, 0);
                    vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, true);


                    alturaMet = vetorResposta[0];
                    alturaProj = vetorResposta[1];
                    tempo = vetorResposta[2];
                    contaerros = 0;
                    //realiza o teste semelhante ao que foi feito acima
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
                    //Caso o contaerros seja maior que 0 significa que o ângulo foi valido, desse modo encontramos
                    //o primeiro ângulo valido do range
                    if (contaerros > 0)
                    {
                        //desse ângulo é subtraido -1 porque se a partir daquele ângulo acerta, então o range do ângulo
                        //começa daquele ângulo-1 pra frente.
                        rangeDoAngulo[0] = i - 1;
                        //sai do for
                        break;
                    }
                }
                contaerros = 0;
                //a partir do ângulo em questão+1 é testado o ângulo limite desse range, indo novamente até 90
                for (int i = rangeDoAngulo[0] + 1; i < 90; i++)
                {
                    angulo = i;
                    Projetil1 = new Projetil(angulo, 0);
                    vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, true);

                    alturaMet = vetorResposta[0];
                    alturaProj = vetorResposta[1];
                    tempo = vetorResposta[2];
                    vo = vetorResposta[3];
                    contaerros = 0;
                    //aqui está uma negação do if utilizado anteriormente. A função desse if é buscar as respostas erradas
                    //caso sejam ecnontradas o contaerros tem um acréscimo
                    if (Math.Abs(alturaMet - alturaProj) >= 1 || tempo < 0 || alturaMet < 0)
                    {
                        contaerros++;
                    }
                    //testa a velocidade inicial para quando o delta é positivo
                    vetorResposta = Calculadora.calculoVo(angulo, Meteoro1, Projetil1, false);

                    alturaMet = vetorResposta[0];
                    alturaProj = vetorResposta[1];
                    tempo = vetorResposta[2];
                    vo = vetorResposta[3];
                    if (Math.Abs(alturaMet - alturaProj) >= 1 || tempo < 0 || alturaMet < 0)
                    {
                        contaerros++;
                    }
                    //caso haja dois erros significa que para aquele ângulo não ha velocidades inicias validas
                    //logo esse ângulo se torna o range limite de acerto
                    if (contaerros == 2)
                    {
                        rangeDoAngulo[1] = i;
                        break;
                    }
                    else if (i == 89)
                    {
                        //caso i seja igual a 89 o limite de acerto é 89 uma vez que 90 graus seria um tiro pra cima,
                        //o que impossibilitaria o acerto
                        rangeDoAngulo[1] = 89;
                        break;
                    }
                }
                //Aqui é apresentado para o usuario uma mensagem contendo o range do ângulo armazenado no vetor rangedoangulo
                MessageBox.Show($"Para acertar o alvo o ângulo deve estar entre {rangeDoAngulo[0]}° e {rangeDoAngulo[1]}°");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Canhao c = new Canhao(Meteoro1.DistanciaDoCanhao);
            c.Show();
            this.Close();
        }
    }
}

