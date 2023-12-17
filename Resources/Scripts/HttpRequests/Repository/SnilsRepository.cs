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
    class SnilsRepository
    {
        private string URL = ApiConstants.API_URL + "snils";

        public Snils[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Snils[]>(URL).Result;

            return response;
        }

        public Snils[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Snils[]>($"{URL}/student?studentId={studentId}").Result;

            return response;
        }
    }
}
