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

        public MedicalPolicyEntity Post(MedicalPolicyEntity medicalPolicy)
        {
            HttpClient client = new HttpClient();

            using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(medicalPolicy), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PostAsync(URL, jsonContent).Result;

            return null;
        }

        public MedicalPolicyEntity Put(MedicalPolicyEntity medicalPolicy)
        {
            HttpClient client = new HttpClient();

            using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(medicalPolicy), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PutAsync(URL, jsonContent).Result;

            return null;
        }

        public void DeleteById(long? id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DeleteAsync($"{URL}/{id}");
        }
    }
}
