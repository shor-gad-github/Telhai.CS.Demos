using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Telhai.CS.Demos.Models;

namespace Telhai.CS.Demos
{
    /// <summary>
    /// Interaction logic for BindingDemo.xaml
    /// </summary>
    public partial class BindingDemo : Window
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public  BindingDemo()
        {
            InitializeComponent();

            this.Loaded +=  BindingDemo_Loaded;

            lbUsers.ItemsSource = users;

        }

        private async void BindingDemo_Loaded(object sender, RoutedEventArgs e)
        {
            List<Student> list =   await  HttpStudentsRepository.Instance.GetAllStudentsAsync();
            lbUsers.ItemsSource = list;


        }

       static int id = 0;
        private async void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            id++;
          string idCounter = id.ToString();
            Student s = new Student { Id = "", Name = "Name_" + idCounter, Age = 18+id };
            await HttpStudentsRepository.Instance.AddStudentAsync(s);

            //Reload
            List<Student> list = await HttpStudentsRepository.Instance.GetAllStudentsAsync();
            lbUsers.ItemsSource = list;

        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
          //  if (lbUsers.SelectedItem != null)
            //    (lbUsers.SelectedItem as User).Name = "Random Name";
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            //if (lbUsers.SelectedItem != null)
             //   users.Remove(lbUsers.SelectedItem as User);
        }
    }
}
