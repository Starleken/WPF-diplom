using Diplom.Resources.Model;
using Diplom.Resources.Model.Activity;
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
    class ActivityRepository
    {
        private string URL = ApiConstants.API_URL + "activity";

        public Activity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Activity[]>(URL).Result;

            return response;
        }

        public Activity PostActivity(Activity activity)
        {
            HttpClient client = new HttpClient();

            using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(activity), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PostAsync(URL, jsonContent).Result;

            return null;
        }
    }
}
