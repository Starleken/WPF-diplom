using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model.Activity
{
    public class ActivityType
    {
        public long? id { get; set; }
        public string name { get; set; }

        public ActivityType()
        {
            
        }

        public ActivityType(long? id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
