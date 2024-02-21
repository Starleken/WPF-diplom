using Diplom.Resources.Model;
using Diplom.Resources.Requests.MedicalPolicy;
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
    class MedicalPolicyRepository
    {
        private string URL = ApiConstants.API_URL + "medicalPolicy";

        public MedicalPolicyEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<MedicalPolicyEntity[]>(URL).Result;

            return response;
        }

        public MedicalPolicyEntity[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<MedicalPolicyEntity[]>($"{URL}/student?studentId={studentId}").Result;

            return response;
        }

        public MedicalPolicyEntity Post(MedicalPolicyCreateRequest createRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("medicalPolicy");
            request.AddFile("image", imagePath);

            request.AddParameter("number", createRequest.number);
            request.AddParameter("studentId", createRequest.studentId);
            request.AddParameter("issuingOrganization", createRequest.issuingOrganization);

            client.Post(request);

            return null;
        }

        public MedicalPolicyEntity Put(MedicalPolicyUpdateRequest updateRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("medicalPolicy");

            if (!imagePath.Contains("http"))
            {
                request.AddFile("image", imagePath);
            }

            request.AddParameter("id", updateRequest.id);
            request.AddParameter("number", updateRequest.number);
            request.AddParameter("issuingOrganization", updateRequest.issuingOrganization);

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
