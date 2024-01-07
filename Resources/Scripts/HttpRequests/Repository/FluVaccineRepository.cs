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
    }
}
