using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Telhai.CS.Demos.Models
{
    public class HttpStudentsRepository 
    {
        private List<Student> _students;
        //02 Static Member private
        HttpClient clientApi;

        static private HttpStudentsRepository _instance = null;

        //01 change to private
        private HttpStudentsRepository()
        {
           
            clientApi = new HttpClient();
            clientApi.BaseAddress = new Uri("https://localhost:7070");
        }

        //03 Get Factory Of StudentsRepository  as singelton
        public static HttpStudentsRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HttpStudentsRepository();

                }
                return _instance;
            }
        }


        public async Task<List<Student>> GetAllStudentsAsync()
        {
            HttpResponseMessage response =  await clientApi.GetAsync("api/students");
            if (response != null)
            {
                response.EnsureSuccessStatusCode();
                string? dataString = await response.Content.ReadAsStringAsync();
                var students = JsonSerializer.Deserialize<List<Student>>(dataString);
                if (students != null)
                {
                    return students;
                }
            }
            return new List<Student>();
        }


        public async Task AddStudentAsync(Student student)
        {
            try
            {
               
                    //var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonStudentString = JsonSerializer.Serialize<Student>(student);

                    var content = new StringContent(jsonStudentString, Encoding.UTF8, "application/json");
                    var response = await clientApi.PostAsync("api/students", content);
                    if (response != null)
                    {
                       //  var jsonString = await response.Content.ReadAsStringAsync();
                       // return JsonConvert.DeserializeObject<object>(jsonString);
                    }
                
            }
            catch (Exception ex)
            {
               
            }
            
        }

        public void UpdateStudent(Student student)
        {
           

        }

        public async Task RemoveStudent(string id)
        {
            HttpResponseMessage response = await clientApi.DeleteAsync("api/students/" + id);
            if (response != null)
            {
                response.EnsureSuccessStatusCode();
                //..
            }
        }
    }
}
