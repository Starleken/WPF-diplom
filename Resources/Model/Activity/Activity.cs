using System;
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
        public User user { get; set; }

        public Activity()
        {
            
        }

        public Activity(int id, string name, DateTime date, int place, string imageURL, ActivityLevel activityLevel, ActivityType activityType)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.place = place;
            this.imageURL = imageURL;
            this.activityLevel = activityLevel;
            this.activityType = activityType;
        }
    }
}
