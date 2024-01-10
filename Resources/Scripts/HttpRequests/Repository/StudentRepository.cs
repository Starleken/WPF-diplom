using Diplom.Resources.Model;
using Diplom.Resources.Scripts.DbConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.HttpRequests.Repository
{
    internal class StudentRepository
    {
        private string URL = ApiConstants.API_URL + "student";

        public StudentEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<StudentEntity[]>(URL).Result;

            return response;
        }

        public StudentEntity[] GetStudentsByGroup(long? id)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<StudentEntity[]>($"{URL}/group?groupId={id}").Result;

            return response;
        }

        public StudentEntity GetStudentsByUser(long? id)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<StudentEntity>($"{URL}/user?userId={id}").Result;

            return response;
        }

        public StudentEntity PutStudent(StudentEntity student)
        {
            HttpClient client = new HttpClient();

            using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PutAsync(URL, jsonContent).Result;

            return null;
        }

        public void DeleteById(long? id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DeleteAsync($"{URL}/{id}");
        }
    }
}
