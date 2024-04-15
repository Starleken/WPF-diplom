using Diplom.Resources.Model;
using Diplom.Resources.Requests.Fluorography;
using Diplom.Resources.Requests.Passport;
using Diplom.Resources.Scripts.DbConstants;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.HttpRequests.Repository
{
    internal class PassportRepository
    {
        private string URL = ApiConstants.API_URL + "passports";

        public PassportEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<PassportEntity[]>(URL).Result;

            return response;
        }

        public PassportEntity[] GetByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();

            PassportEntity response;
            try
            {
                response = httpClient.GetFromJsonAsync<PassportEntity>($"{URL}/student?studentId={studentId}").Result;
            }
            catch (Exception ex)
            {
                return new PassportEntity[0];
            }
            

            return new PassportEntity[] {response};
        }

        public FluorographyEntity Post(PassportCreateRequest createRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("passports");
            request.AddFile("image", imagePath);

            request.AddParameter("series", createRequest.series);
            request.AddParameter("number", createRequest.number);

            string date = $"{createRequest.issueDate.Year}-{createRequest.issueDate.Month}-{createRequest.issueDate.Day}";

            request.AddParameter("issueDate", date);
            request.AddParameter("issuingOrganization", createRequest.issuingOrganization);
            request.AddParameter("studentId", createRequest.studentId);

            client.Post(request);

            return null;
        }

        public FluorographyEntity Put(PassportUpdateRequest updateRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("passports");

            if (!imagePath.Contains("http"))
            {
                request.AddFile("image", imagePath);
            }

            request.AddParameter("id", updateRequest.id);
            request.AddParameter("series", updateRequest.series);

            string date = $"{updateRequest.issueDate.Year}-{updateRequest.issueDate.Month}-{updateRequest.issueDate.Day}";

            request.AddParameter("issueDate", date);
            request.AddParameter("issuingOrganization", updateRequest.issuingOrganization);
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
