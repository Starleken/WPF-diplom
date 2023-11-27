using Diplom.Resources.Model;
using Diplom.Resources.Scripts.DbConstants;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.HttpRequests
{
    class UserGetter
    {
        private string URL = ApiConstants.API_URL + "user";

        public User[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<User[]>(URL).Result;

            return response;
        }
    }
}
