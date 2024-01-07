using Diplom.Resources.Model;
using Diplom.Resources.Model.Activity;
using Diplom.Resources.Requests;
using Diplom.Resources.Scripts.DbConstants;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
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

        public Activity[] GetActivitiesByStudentId(long? id)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Activity[]>($"{URL}/student?studentId={id}").Result;

            return response;
        }

        public Activity PostActivity(ActivityCreateRequest createRequest, string imagePath)
        {    
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("activity");
            request.AddFile("image", imagePath);

            request.AddParameter("name", createRequest.name);
            request.AddParameter("place", createRequest.place);
            request.AddParameter("activityTypeId", createRequest.activityTypeId.Value);
            request.AddParameter("activityLevelId", createRequest.activityLevelId);
            request.AddParameter("studentId", createRequest.studentId.Value);

            string date = $"{createRequest.date.Year}-{createRequest.date.Month}-{createRequest.date.Day}";

            request.AddParameter("date", date);

            client.Post(request);

            return null;
        }

        public Activity PutActivity(ActivityUpdateRequest updateRequest, string imagePath)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("activity");

            if (!imagePath.Contains("http"))
            {
                request.AddFile("image", imagePath);
            }

            request.AddParameter("id", updateRequest.id);
            request.AddParameter("name", updateRequest.name);
            request.AddParameter("place", updateRequest.place);
            request.AddParameter("activityTypeId", updateRequest.activityTypeId.Value);
            request.AddParameter("activityLevelId", updateRequest.activityLevelId.Value);

            string date = $"{updateRequest.date.Year}-{updateRequest.date.Month}-{updateRequest.date.Day}";

            request.AddParameter("date", date);

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
