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

        public Student[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Student[]>(URL).Result;

            return response;
        }

        public Student[] GetStudentsByGroup(long? id)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Student[]>($"{URL}/group?groupId={id}").Result;

            return response;
        }

        public Student GetStudentsByUser(long? id)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Student>($"{URL}/user?userId={id}").Result;

            return response;
        }

        public Student PutStudent(Student student)
        {
            HttpClient client = new HttpClient();

            using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PutAsync(URL, jsonContent).Result;

            return null;
        }
    }
}
