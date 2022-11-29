using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.Demos.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }


        public Student():this("",-1)
        {
        }

        public Student(string name,int age)
        {
            this.Name = name;
            this.Age = age;
            this.Id = Guid.NewGuid().ToString();
        }



    }
}
