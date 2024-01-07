using Diplom.Resources.Model;
using Diplom.Resources.Scripts.DbConstants;
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
        private string URL = ApiConstants.API_URL + "passport";

        public PassportEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<PassportEntity[]>(URL).Result;

            return response;
        }

        public PassportEntity[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<PassportEntity[]>($"{URL}/student?studentId={studentId}").Result;

            return response;
        }
    }
}
