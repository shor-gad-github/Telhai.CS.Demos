using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    /// Interaction logic for StudentsWindow.xaml
    /// </summary>
    public partial class StudentsWindow : Window
    {
        IStudentsRepository repo;

        public StudentsWindow(IStudentsRepository repo)
        {
            InitializeComponent();
            this.repo = repo;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.listBoxStudents.ItemsSource = repo.GetAllStudents();
         

        }

        private void listBoxStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listBoxStudents.SelectedItem is Student s)
            {
                this.txtId.Text = s.Id;
                this.txtName.Text = s.Name;
                this.txtAge.Text = s.Age.ToString();
            }
        }


        int iNoName = 1;
        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Student s = new Student { Name = "NoName_" + iNoName};
            this.repo.AddStudent(s);
            iNoName++;
         
            this.listBoxStudents.ItemsSource = this.repo.GetAllStudents();
            //SetSelectedByIndex(this.listBoxStudents.Items.Count-1);
            SetSelectedById(s.Id);
        }

        private void SetSelectedById(string id)
        {
            for (int i = 0; i < this.listBoxStudents.Items.Count; i++)
            {

                Student? s = listBoxStudents.Items[i] as Student;
                if (s!=null)
                {
                    if (s.Id==id)
                        this.listBoxStudents.SelectedItem = s;
                }
            
            }
        }

        private void SetSelectedByIndex(int index)
        {
            if (index>=0 && index < this.listBoxStudents.Items.Count)
            {
                this.listBoxStudents.SelectedIndex = index;
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (this.listBoxStudents.SelectedItem is Student s )
            {
                repo.RemoveStudent(s.Id);
            }
                
            this.listBoxStudents.ItemsSource = repo.GetAllStudents();
            SetSelectedByIndex(0);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.listBoxStudents.SelectedItem is Student s)
            {
                s.Name = txtName.Text;
                int convertedAge;
                bool isOk = int.TryParse(txtAge.Text, out convertedAge);
                if (isOk)
                {
                    s.Age = convertedAge;
                }
                s.Id = this.txtId.Text;

                this.repo.UpdateStudent(s);
                this.listBoxStudents.ItemsSource = repo.GetAllStudents();
                this.SetSelectedById(s.Id);
            }
        }

        private void btnSaveAll_Click(object sender, RoutedEventArgs e)
        {
            List<Student> students = repo.GetAllStudents();

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonStudentsString = JsonSerializer.Serialize<List<Student>>(students, options);

            if (!Directory.Exists("AppData"))
            { 
                Directory.CreateDirectory("AppData");
            }  
           
            File.WriteAllText("AppData/students.json", jsonStudentsString);
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string jsonPath =   openFileDialog.FileName;
                this.PathLoader.Text = jsonPath;



            }
                   
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            if (this.PathLoader.Text != string.Empty)
            {
                //1) Load Student from Text As Object
                //From User Selected File
                //
                string studentsText = File.ReadAllText(this.PathLoader.Text);
                var studentsList =
                JsonSerializer.Deserialize<Student[]>(studentsText);
                //2)Add Objects to Repo Manager
        
                foreach (Student item in studentsList)
                {
                    repo.AddStudent(item);
                }
                //3)Sync GUI LIST
                this.listBoxStudents.ItemsSource = repo.GetAllStudents(); ;



            }
        }
    }
}
