﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model.Activity
{
    public class Activity
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public int place { get; set; }
        public string imageURL { get; set; }
        public ActivityLevel activityLevel { get; set; }
        public ActivityType activityType { get; set; }
        public StudentEntity student { get; set; }
    }
}
