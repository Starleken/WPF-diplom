using Diplom.Resources.Model;
using Diplom.Resources.Requests.Fluorography;
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
    class FluorographyRepository
    {
        private string URL = ApiConstants.API_URL + "fluorographies";

        public FluorographyEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<FluorographyEntity[]>(URL).Result;

            return response;
        }

        public FluorographyEntity[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();

            FluorographyEntity response;
            try
            {
                response = httpClient.GetFromJsonAsync<FluorographyEntity>($"{URL}/student?studentId={studentId}").Result;
            }
            catch (Exception ex)
            {
                return new FluorographyEntity[0];
            }

            return new FluorographyEntity[] { response };
        }

        public FluorographyEntity Post(FluorographyCreateRequest createRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("fluorographies");
            request.AddFile("image", imagePath);

            request.AddParameter("number", createRequest.number);
            request.AddParameter("studentId", createRequest.studentId.Value);

            string date = $"{createRequest.createDate.Year}-{createRequest.createDate.Month}-{createRequest.createDate.Day}";

            request.AddParameter("createDate", date);

            client.Post(request);

            return null;
        }

        public FluorographyEntity Put(FluorographyUpdateRequest updateRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("fluorographies");

            if (!imagePath.Contains("http"))
            {
                request.AddFile("image", imagePath);
            }

            request.AddParameter("id", updateRequest.id);
            request.AddParameter("number", updateRequest.number);

            string date = $"{updateRequest.createDate.Year}-{updateRequest.createDate.Month}-{updateRequest.createDate.Day}";

            request.AddParameter("createDate", date);

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
