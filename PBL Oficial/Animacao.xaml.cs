using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace PBL_Oficial
{

    public partial class Animacao : Window
    {
        private PlotModel model;
        private LineSeries series;
        private EllipseAnnotation ball;
        private EllipseAnnotation projectile;
        private double ballPositionX;
        private double ballPositionY;
        private double projectilePositionX;
        private double projectilePositionY;
        private DateTime startTime;
        private TextAnnotation timerAnnotation;
        private double tempo;
        private LineSeries tracejadobola;
        private LineSeries tracejadoprojetil;
        private Projetil Projetil;
        private double TempoAcerto;


        public Animacao(double tempo, double alturaMeteoro, double alturaImpacto, double DistanciaCanhao, double vo, double angulo)
        {
            InitializeComponent();
            TempoAcerto = tempo;
            Projetil = new Projetil(vo, angulo);
            // Configura o modelo do gráfico
            model = new PlotModel { Title = "Gráfico X e Y" };

            // Configura o eixo X (horizontal)
            var xAxis = new LinearAxis { Position = AxisPosition.Bottom, Minimum = 0, Maximum = 4000 };
            model.Axes.Add(xAxis);

            // Configura o eixo Y (vertical)
            var yAxis = new LinearAxis { Position = AxisPosition.Left, Minimum = 0, Maximum = 6000 };
            model.Axes.Add(yAxis);

            series = new LineSeries();
            model.Series.Add(series);


            tracejadobola = new LineSeries
            {
                StrokeThickness = 1,
                Color = OxyColors.Black,
                LineStyle = LineStyle.Dash
            };
            model.Series.Add(tracejadobola);

            // Adicionar linha tracejada para a rota do projétil
            tracejadoprojetil = new LineSeries
            {
                StrokeThickness = 1,
                Color = OxyColors.Black,
                LineStyle = LineStyle.Dash
            };
            model.Series.Add(tracejadoprojetil);

            // Configura a posição inicial da bola
            ballPositionX = DistanciaCanhao;
            ballPositionY = alturaMeteoro;
            ball = new EllipseAnnotation
            {
                X = ballPositionX,
                Y = ballPositionY,
                Width = 200,
                Height = 500,
                Stroke = OxyColors.Black,
                Fill = OxyColors.Red
            };
            model.Annotations.Add(ball);

            // Configurar a posição inicial do projetil (x100)
            projectilePositionX = 0;
            projectilePositionY = 0;
            projectile = new EllipseAnnotation
            {
                X = projectilePositionX,
                Y = projectilePositionY,
                Width = 200,
                Height = 500,
                Stroke = OxyColors.Black,
                Fill = OxyColors.Blue
            };
            model.Annotations.Add(projectile);

            timerAnnotation = new TextAnnotation
            {
                TextPosition = new DataPoint(3000, 5000), // Posição inicial
                Stroke = OxyColors.Transparent,
                Background = OxyColor.FromRgb(255, 255, 255)

            };
            model.Annotations.Add(timerAnnotation);


            // Associar o modelo ao plotView (Local onde o gráfico será gerado)
            plotView.Model = model;

            Projetil = new Projetil(vo, angulo);
            Acerto a = new Acerto(Projetil, alturaImpacto, tempo, this, DistanciaCanhao, angulo);

            Executa_Animacao(tempo, alturaMeteoro, alturaImpacto, DistanciaCanhao, Projetil, a);


        }

        private async void Executa_Animacao(double tempo, double alturaMeteoro, double alturaImpacto, double DistanciaCanhao, Projetil p, Acerto a)
        {
            AnimateProjectile(tempo, alturaMeteoro, alturaImpacto, DistanciaCanhao);
            AnimateBall(tempo, alturaMeteoro, alturaImpacto);
            await AbrirJanela(Projetil, a, tempo);

            a.Closing += JanelaSecundariaClosing;
        }

        private void JanelaSecundariaClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Fecha a JanelaPrincipal quando a JanelaSecundaria for fechada
            this.Close();
        }

        private async Task AbrirJanela(Projetil p, Acerto a, double tempo)
        {
            int tempoInt = (int)tempo;
            await Task.Delay(1000 * (tempoInt));
            a.Show();
        }

        private async void AnimateProjectile(double tempo, double alturaMeteoro, double alturaImpacto, double DistanciaCanhao)
        {
            double initialX = projectilePositionX;
            double initialY = projectilePositionY;
            double targetX = DistanciaCanhao;
            double targetY = alturaImpacto;
            double fallDurationMs = tempo;
            tempo = fallDurationMs;

            DateTime startTime = DateTime.Now;

            while (projectilePositionX < targetX || projectilePositionY < targetY)
            {


                //Cálculo para movimentar projétil
                double progress = (DateTime.Now - startTime).TotalSeconds / fallDurationMs;
                double segundos = (DateTime.Now - startTime).TotalSeconds;
                projectilePositionX = initialX + (Projetil.Vox) * segundos;
                projectilePositionY = initialY + (Projetil.Voy) * segundos - 4.9 * Math.Pow(segundos, 2);
                tracejadoprojetil.Points.Add(new DataPoint(projectilePositionX, projectilePositionY));


                // Verificar se o projetil atingiu as coordenadas desejadas
                if (segundos >= tempo)
                {
                    projectilePositionX = targetX;
                    projectilePositionY = targetY;
                    UpdateTimer((DateTime.Now - startTime).TotalSeconds);
                    break; // Interrompe a animação do projetil quando atinge as coordenadas desejadas
                }

                // Atualiza o trajeto e assimila ao gráfico
                projectile.X = projectilePositionX;
                projectile.Y = projectilePositionY;

                Dispatcher.Invoke(() => plotView.InvalidatePlot());

                await Task.Delay(16);
                UpdateTimer((DateTime.Now - startTime).TotalSeconds);
            }
        }

        private async void AnimateBall(double tempo, double alturaMeteoro, double alturaImpacto)
        {
            double initialY = alturaMeteoro; // Posição inicial da bola
            double finalY = alturaImpacto;   // Posição final da bola
            double animationDurationMs = tempo;
            DateTime startTime = DateTime.Now;

            double vm = (finalY - initialY) / tempo;
            while (ballPositionY > finalY)
            {
                double progress = (DateTime.Now - startTime).TotalSeconds / animationDurationMs;
                ballPositionY = initialY - (50) * (DateTime.Now - startTime).TotalSeconds;



                // Verificar se a bola atingiu ou ultrapassou a posição final desejada
                if ((DateTime.Now - startTime).TotalSeconds >= tempo)
                {
                    ballPositionY = finalY;
                    break;
                }

                // Atualiza a posição da bola e assimila ao gráfico
                ball.Y = ballPositionY;
                tracejadobola.Points.Add(new DataPoint(ballPositionX, ballPositionY));
                Dispatcher.Invoke(() => plotView.InvalidatePlot());

                await Task.Delay(16);
            }
        }
        private async void UpdateTimer(double tempo)
        {
            if (TempoAcerto < tempo)
            {
                tempo = TempoAcerto;
            }
            timerAnnotation.Text = $"Tempo: {tempo.ToString("F2")}s";
            Dispatcher.Invoke(() => plotView.InvalidatePlot());
        }

    }
}

