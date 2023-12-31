﻿using Diplom.Resources.Model.Activity;
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
    class ActivityTypeRepository
    {
        private string URL = ApiConstants.API_URL + "activityType";

        public ActivityTypeEntity[] GetAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetFromJsonAsync<ActivityTypeEntity[]>(URL).Result;

            return response;
        }
    }
}
