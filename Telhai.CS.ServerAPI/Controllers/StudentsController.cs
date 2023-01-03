using Microsoft.AspNetCore.Mvc;
using Telhai.CS.ServerAPI.Models;
using Telhai.CS.ServerAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Telhai.CS.ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentsRepository repo;

        public StudentsController()
        {
            repo = StudentsRepository.Instance;
            if (repo.Students.Length == 0)
            {
                Student s1 = new Student("DolandDuck", 60);
                Student s2 = new Student("MickyMouse", 30);
                repo.AddStudent(s1);
                repo.AddStudent(s2);
            }
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return this.repo.Students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(string id)
        {
           Student? student = this.repo.Students.Where(s=>s.Id == id).SingleOrDefault();
           if (student!=null)
              return student;
           else
                return new Student {Id="-1" };
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
