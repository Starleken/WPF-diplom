using Diplom.Resources.Model;
using Diplom.Resources.Scripts.DbConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.HttpRequests.Repository
{
    class MedicalPolicyRepository
    {
        private string URL = ApiConstants.API_URL + "medicalPolicy";

        public MedicalPolicy[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<MedicalPolicy[]>(URL).Result;

            return response;
        }

        public MedicalPolicy[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<MedicalPolicy[]>($"{URL}/student?studentId={studentId}").Result;

            return response;
        }
    }
}
