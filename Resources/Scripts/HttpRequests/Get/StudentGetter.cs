using Diplom.Resources.Model;
using Diplom.Resources.Scripts.DbConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.HttpRequests.Get
{
    class StudentGetter
    {
        private string URL = ApiConstants.API_URL + "student";

        public Student[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<Student[]>(URL).Result;

            return response;
        }
    }
}
