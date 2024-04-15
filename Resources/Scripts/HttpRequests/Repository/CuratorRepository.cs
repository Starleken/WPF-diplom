using Diplom.Resources.Model;
using Diplom.Resources.Requests.Curator;
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
    internal class CuratorRepository
    {
        private string URL = ApiConstants.API_URL + "curators";

        public CuratorEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<CuratorEntity[]>(URL).Result;

            return response;
        }

        public CuratorEntity GetCuratorByUser(long? userId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<CuratorEntity>($"{URL}/user?userId={userId}").Result;

            return response;
        }

        public CuratorEntity Create(CuratorCreateRequest createRequest)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("curator");

            request.AddJsonBody(createRequest);

            client.Post(request);

            return null;
        }

        public CuratorEntity Update(CuratorUpdateRequest updateRequest)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("curator");

            request.AddJsonBody(updateRequest);

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
