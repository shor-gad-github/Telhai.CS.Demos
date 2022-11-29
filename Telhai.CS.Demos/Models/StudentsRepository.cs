using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.Demos.Models
{
    public class StudentsRepository
    {
        private List<Student> _students;
        public StudentsRepository()
        {
            _students = new List<Student>();
        }

        public Student[] Students
        {
            get { return _students.ToArray();  }
        }

        public void AddStudent(Student student)
        {
            this._students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            int indexFound =  this._students.FindIndex(s => s.Id == student.Id);
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
