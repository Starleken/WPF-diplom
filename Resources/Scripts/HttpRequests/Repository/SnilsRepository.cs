using Diplom.Resources.Model;
using Diplom.Resources.Requests.Snils;
using Diplom.Resources.Scripts.DbConstants;
using RestSharp;
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

        public SnilsEntity Post(SnilsCreateRequest createRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("snils");
            request.AddFile("image", imagePath);

            request.AddParameter("number", createRequest.number);
            request.AddParameter("studentId", createRequest.studentId);

            client.Post(request);

            return null;
        }

        public SnilsEntity Put(SnilsUpdateRequest updateRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("snils");

            if (!imagePath.Contains("http"))
            {
                request.AddFile("image", imagePath);
            }

            request.AddParameter("id", updateRequest.id);
            request.AddParameter("number", updateRequest.number);

            client.Put(request);

            return null;
        }
    }
}
