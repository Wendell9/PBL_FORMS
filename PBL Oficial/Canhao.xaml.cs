﻿using System;
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
    /// Lógica interna para Canhao.xaml
    /// </summary>
    public partial class Canhao : Window
    {
        private double AlturaMeteoro;
        //Inicializa a classe e atribui um valor para o atributo Altura Meteoro
        public Canhao(double altura)
        {
            AlturaMeteoro = altura;
            InitializeComponent();
        }
        //Cada botão corresponde a uma distância do canhão em relação ao meteoro, para cada opção de clique o botão
        //irá instanciar um ângulo passando como parâmetros a altura do meteoro recebida na instanciação da classe canhão 
        //e a respectiva distância do canhão

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Angulo angulo = new Angulo(AlturaMeteoro,1000.0);
            angulo.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Angulo angulo = new Angulo(AlturaMeteoro, 750.0);
            angulo.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Angulo angulo = new Angulo(AlturaMeteoro, 500.0);
            angulo.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Angulo angulo = new Angulo(AlturaMeteoro, 250.0);
            angulo.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow m= new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
