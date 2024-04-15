using Diplom.Resources.Model;
using Diplom.Resources.Requests.Snils;
using Diplom.Resources.Requests.Student;
using Diplom.Resources.Scripts.DbConstants;
using RestSharp;
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
    internal class StudentRepository
    {
        private string URL = ApiConstants.API_URL + "students";

        public StudentEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<StudentEntity[]>(URL).Result;

            return response;
        }

        public StudentEntity[] GetStudentsByGroup(long? id)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<StudentEntity[]>($"{URL}/group?groupId={id}").Result;

            return response;
        }

        public StudentEntity GetStudentsByUser(long? id)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<StudentEntity>($"{URL}/user?userId={id}").Result;

            return response;
        }

        public StudentEntity Post(StudentCreateRequest createRequest)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("student");

            request.AddJsonBody(createRequest);

            client.Post(request);

            return null;
        }

        public StudentEntity Put(StudentUpdateRequest updateRequest)
        {
            var client = new RestClient(ApiConstants.API_URL);
            var request = new RestRequest("student");

            request.AddJsonBody(updateRequest);

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
