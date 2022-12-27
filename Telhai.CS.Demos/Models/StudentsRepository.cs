using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.Demos.Models
{
    public class StudentsRepository : IStudentsRepository
    {
        private List<Student> _students;
        //02 Static Member private
        static private StudentsRepository _instance = null;

        //01 change to private
        private StudentsRepository()
        {
            _students = new List<Student>();
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




        public Student[] Students
        {
            get { return _students.ToArray(); }

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
