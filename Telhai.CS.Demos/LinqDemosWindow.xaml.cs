﻿using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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

namespace Telhai.CS.Demos
{
    /// <summary>
    /// Interaction logic for LinqDemosWindow.xaml
    /// </summary>
    public partial class LinqDemosWindow : Window
    {
        public LinqDemosWindow()
        {
            InitializeComponent();
        }

        public bool MyFunc(int n)
        {
            return n < 5;
        }

        private void Demo1_Click(object sender, RoutedEventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 10 };
            //Query Syntav
            var data = from num in numbers
                       where num < 5
                       select (num);

            //Lambda function Syntax
            var dataFunc = numbers.Where(n=>n<5).Select(n => n * 2);


            //Lambda function Syntax
            var dataFuncRef = numbers.Where(MyFunc).Select(n => n*2);


            foreach (var item in dataFunc)
            {
                ResultTxtBox.Text += "[" + item.ToString() + "] ";
            }
        }

        private void Demo2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
    