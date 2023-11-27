using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.HttpRequests.Post
{
    internal class PassPoster
    {
        private readonly string URL = "http://localhost:5001/api/v1/pass";

        //public Task<User> PostUser(Pass pass)
        //{
        //    HttpClient client = new HttpClient();

        //    using var multipartFormContent = new MultipartFormDataContent();
        //    StreamContent fileStreamContent = new StreamContent(File.OpenRead("C:\\Users\\Starleken\\Pictures\\1.jpg"));
        //    fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        //    multipartFormContent.Add(fileStreamContent, name: "Image", fileName: "Image");
          
        //    using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(pass), Encoding.UTF8, "application/json");
        //    multipartFormContent.Add(jsonContent);


        //    HttpResponseMessage responseMessage = client.PostAsync(URL, multipartFormContent).Result;

        //    return null;
        //}
    }
}
