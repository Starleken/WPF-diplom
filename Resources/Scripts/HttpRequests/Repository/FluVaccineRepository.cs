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
    class FluVaccineRepository
    {
        private string URL = ApiConstants.API_URL + "fluVaccine";

        public FluVaccine[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<FluVaccine[]>(URL).Result;

            return response;
        }

        public FluVaccine[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<FluVaccine[]>($"{URL}/student?studentId={studentId}").Result;

            return response;
        }
    }
}
