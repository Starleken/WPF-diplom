using Diplom.Resources.Model;
using Diplom.Resources.Requests.Fluorography;
using Diplom.Resources.Requests.FluVaccine;
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
    class FluVaccineRepository
    {
        private string URL = ApiConstants.API_URL + "fluVaccines";

        public FluVaccineEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<FluVaccineEntity[]>(URL).Result;

            return response;
        }

        public FluVaccineEntity[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<FluVaccineEntity[]>($"{URL}/student?studentId={studentId}").Result;

            return response;
        }

        public FluorographyEntity Post(FluVaccineCreateRequest createRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("fluVaccines");
            request.AddFile("image", imagePath);

            request.AddParameter("studentId", createRequest.studentId);

            string date = $"{createRequest.createDate.Year}-{createRequest.createDate.Month}-{createRequest.createDate.Day}";

            request.AddParameter("createDate", date);

            client.Post(request);

            return null;
        }

        public FluorographyEntity Put(FluVaccineUpdateRequest updateRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("fluVaccines");

            if (!imagePath.Contains("http"))
            {
                request.AddFile("image", imagePath);
            }

            request.AddParameter("id", updateRequest.id);

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
