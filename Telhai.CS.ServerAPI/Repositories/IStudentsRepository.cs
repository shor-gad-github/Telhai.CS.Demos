using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telhai.CS.ServerAPI.Models;

namespace Telhai.CS.ServerAPI.Repositories
{
    public interface IStudentsRepository
    {
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(string id);
        Student[] Students { get;  }

    }
}
