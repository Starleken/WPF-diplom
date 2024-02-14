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
    class NotificationRepository
    {
        private string URL = ApiConstants.API_URL + "notifications";

        public string[] GetAllByStudent(long? studentId)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<string[]>($"{URL}/{studentId}").Result;

            return response;
        }
    }
}
