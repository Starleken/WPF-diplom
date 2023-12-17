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
    class FluorographyRepository
    {
        private string URL = ApiConstants.API_URL + "fluorography";

        public Fluorography[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Fluorography[]>(URL).Result;

            return response;
        }

        public Fluorography[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Fluorography[]>($"{URL}/student?studentId={studentId}").Result;

            return response;
        }
    }
}
