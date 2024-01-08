using Diplom.Resources.Model;
using Diplom.Resources.Requests.Inn;
using Diplom.Resources.Requests.MedicalPolicy;
using Diplom.Resources.Scripts.DbConstants;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.HttpRequests.Repository
{
    internal class InnRepository
    {
        private string URL = ApiConstants.API_URL + "inn";

        public InnEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<InnEntity[]>(URL).Result;

            return response;
        }

        public InnEntity[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<InnEntity[]>($"{URL}/student?studentId={studentId}").Result;

            return response;
        }

        public InnEntity Post(InnCreateRequest createRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("inn");
            request.AddFile("image", imagePath);

            request.AddParameter("number", createRequest.number);
            request.AddParameter("studentId", createRequest.studentId);

            client.Post(request);

            return null;
        }

        public InnEntity Put(InnUpdateRequest updateRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("inn");

            if (!imagePath.Contains("http"))
            {
                request.AddFile("image", imagePath);
            }

            request.AddParameter("id", updateRequest.id);
            request.AddParameter("number", updateRequest.number);

            client.Put(request);

            return null;
        }

        public void DeleteById(long? id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DeleteAsync($"{URL}/{id}");
        }
    }
}
