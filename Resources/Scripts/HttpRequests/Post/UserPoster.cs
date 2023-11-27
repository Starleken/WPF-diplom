using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.HttpRequests.Post
{
    class UserPoster
    {
        private readonly string URL = "http://localhost:5001/api/v1/user";

        //public Task<User> PostUser(User user)
        //{
        //    HttpClient client = new HttpClient();

        //    using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

        //    HttpResponseMessage responseMessage = client.PostAsync(URL, jsonContent).Result;

        //    return null;
        //}
    }
}
