using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telhai.CS.Demos.Models;
using Telhai.CS.Logging;

namespace Telhai.CS.Demos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            //--1.Initilize Calc Window class
            CalcWindow calcWin = new CalcWindow();
            //--2.Show Dialog  (blocking method till window close)
            calcWin.ShowDialog();
            //--3.read the public allExpressions field from calcWin
            List<string> userList = calcWin.allExpressions;
            //--4 copy CalcWindow inner list
            //to current listElem items
            foreach (var item in userList)
            {
                this.listElem.Items.Add(item);
            }
        }
                  
          
                

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

            StudentsWindow s = new StudentsWindow(StudentsRepository.Instance);
            s.Show();
        }

        private void listElem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if (e.AddedItems.Count > 0 )
            {
                int indexSelected =  listElem.SelectedIndex;
                string val =  listElem.SelectedItem.ToString();
               // MessageBox.Show($"Index:{indexSelected+1}\nContent:{val}");
                // string valueSelected = ((string)e.AddedItems[0]);
                //MessageBox.Show(valueSelected);
                
                Logger.Log($"Index:{indexSelected + 1}\nContent:{val}");


            }
            
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            JsonDemos d = new JsonDemos();
            d.Show();
        }

        private void Linq_Click(object sender, RoutedEventArgs e)
        {
            LinqDemosWindow linqDemosWindow = new LinqDemosWindow();
            linqDemosWindow.ShowDialog();
        }

        private void btnBindingDemo_Click(object sender, RoutedEventArgs e)
        {

            BindingDemo d = new BindingDemo();
            d.Show();
           // User user = new User();
            //01-Register Event
         //   user.PropertyChanged += User_PropertyChanged;
           // user.PropertyChanged += CallMe;
         //   user.Name = "XXXXX";

        }

        private void User_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            //User? s = sender as User;
           ///// if (s != null)
           // {

          //  }
            listElem.Items.Add(e.PropertyName);
        }
        private void CallMe(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            listElem.Items.Add(e.PropertyName);

        }

        private void EventsDemo_Click(object sender, RoutedEventArgs e)
        {
            EventsDemo demo = new EventsDemo();
            demo.ColorChangedEvent += Demo_ColorChangedEvent;
            demo.ShowDialog();
        }

        private void Demo_ColorChangedEvent(object? sender, EventArgs e)
        {
            if (sender is EventsDemo windowEventDemo)
            {
                this.Background = new SolidColorBrush(windowEventDemo.SelectedColor);
                stackPanelBtns.Background = new SolidColorBrush(windowEventDemo.SelectedColor); ;
            }
            
        }
    }
}
