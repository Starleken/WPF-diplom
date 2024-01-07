using Diplom.Resources.Model.Activity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Diplom.Resources.Requests
{
    class ActivityCreateRequest
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public int place { get; set; }
        public long? activityTypeId { get; set; }
        public long activityLevelId { get; set; }
        public long? studentId { get; set; }

        public ActivityCreateRequest(Activity activity)
        {
            this.name = activity.name;
            this.date = activity.date;
            this.place = activity.place;
            activityTypeId = activity.activityType.id;
            activityLevelId = activity.activityLevel.id;
            studentId = activity.student.id;
        }
    }
}
