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
    class SnilsRepository
    {
        private string URL = ApiConstants.API_URL + "snils";

        public SnilsEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<SnilsEntity[]>(URL).Result;

            return response;
        }

        public SnilsEntity[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<SnilsEntity[]>($"{URL}/student?studentId={studentId}").Result;

            return response;
        }

        public SnilsEntity Post(SnilsEntity snils)
        {
            HttpClient client = new HttpClient();

            using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(snils), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PostAsync(URL, jsonContent).Result;

            return null;
        }

        public SnilsEntity Put(SnilsEntity snils)
        {
            HttpClient client = new HttpClient();

            using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(snils), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PutAsync(URL, jsonContent).Result;

            return null;
        }
    }
}
