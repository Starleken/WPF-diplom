﻿using Diplom.Resources.Model.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Diplom.Resources.Requests.Activity
{
    class ActivityUpdateRequest
    {
        public long id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string eventPlace { get; set; }
        public int place { get; set; }
        public long? activityTypeId { get; set; }
        public long? activityLevelId { get; set; }

        public ActivityUpdateRequest(ActivityEntity activity)
        {
            id = activity.id;
            name = activity.name;
            date = activity.date;
            place = activity.place;
            eventPlace = activity.eventPlace;
            activityTypeId = activity.activityType.id;
            activityLevelId = activity.activityLevel.id;
        }
    }
}
