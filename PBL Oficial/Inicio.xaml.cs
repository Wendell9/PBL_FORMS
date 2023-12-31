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
    /// Lógica interna para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //cria uma pagina de consultar e faz com que essa pagina apareça, enquanto a pagina de inicio é fechada
            Consultar consultar = new Consultar();
            consultar.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //cria uma pagina de MainWindow, em que a altura do meteoro é escolhida, e
            //faz com que essa pagina apareça, enquanto a pagina de inicio é fechada
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
