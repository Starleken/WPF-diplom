﻿using Diplom.Resources.Model;
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
    class UserRepository
    {
        private string URL = ApiConstants.API_URL + "user";

        public UserEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<UserEntity[]>(URL).Result;

            return response;
        }

        public UserEntity findByLoginAndPassword(string login, string password)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<UserEntity>($"{URL}/auth?login={login}&password={password}").Result;

            return response;
        }
    }
}