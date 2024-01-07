using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.HttpRequests.Post
{
    class StudentPoster
    {
        private readonly string URL = "http://localhost:8080/api/v1/student";

        public StudentEntity PostStudent(StudentEntity student)
        {
            HttpClient client = new HttpClient();

            using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PostAsync(URL, jsonContent).Result;

            return null;
        }
    }
}
