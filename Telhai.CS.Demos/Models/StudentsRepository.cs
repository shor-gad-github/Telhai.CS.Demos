using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Telhai.CS.Demos.Models
{
    public class StudentsRepository : IStudentsRepository
    {
        private List<Student> _students;
        //02 Static Member private
        HttpClient clientApi; 

        static private StudentsRepository _instance = null;

        //01 change to private
        private StudentsRepository()
        {
            _students = new List<Student>();
            clientApi = new HttpClient();
            clientApi.BaseAddress = new Uri("https://localhost:7070");
        }

        //03 Get Factory Of StudentsRepository  as singelton
        public static StudentsRepository Instance
        {
            get
            { 
              if (_instance == null)
                {
                    _instance = new StudentsRepository();

                }
                return _instance;
            }
        }


        public List<Student>  GetStudents()
        {
            var response = clientApi?.GetAsync("api/students").Result;
          //  response.EnsureSuccessStatusCode();
            string? dataString =  response?.Content.ReadAsStringAsync().Result;
           var students = JsonSerializer.Deserialize<List<Student>>(dataString);
            return students;
        }



        public Student[] Students
        {
            get {
                 var st =  GetStudents();


                return st.ToArray(); }

        }

        public void AddStudent(Student student)
        {
            this._students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            int indexFound = this._students.FindIndex(s => s.Id == student.Id);
            if (indexFound >= 0)
            {
                this._students[indexFound] = student;

            }


        }

        public void RemoveStudent(string id)
        {
            int indexFound = this._students.FindIndex(s => s.Id == id);
            if (indexFound >= 0)
            {
                this._students.RemoveAt(indexFound);
            }
        }

    }
}
