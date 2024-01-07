using Diplom.Resources.Model.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Diplom.Resources.Requests
{
    class ActivityUpdateRequest
    {
        public long id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public int place { get; set; }
        public long? activityTypeId { get; set; }
        public long? activityLevelId { get; set; }

        public ActivityUpdateRequest(Activity activity)
        {
            this.id = activity.id;
            this.name = activity.name;
            this.date = activity.date;
            this.activityTypeId = activity.activityType.id;
            this.activityLevelId = activity.activityLevel.id;
        }
    }
}
