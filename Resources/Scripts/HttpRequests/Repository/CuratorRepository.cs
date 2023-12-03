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
    internal class CuratorRepository
    {
        private string URL = ApiConstants.API_URL + "curator";

        public Curator[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Curator[]>(URL).Result;

            return response;
        }

        public Curator Create(Curator curator)
        {
            HttpClient client = new HttpClient();

            using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(curator), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PostAsync(URL, jsonContent).Result;

            return null;
        }

        public Curator Update(Curator curator)
        {
            HttpClient client = new HttpClient();

            using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(curator), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PutAsync(URL, jsonContent).Result;

            return null;
        }
    }
}
