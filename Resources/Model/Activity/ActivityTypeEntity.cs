using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model.Activity
{
    public class ActivityTypeEntity
    {
        public long? id { get; set; }
        public string name { get; set; }

        public ActivityTypeEntity()
        {
            
        }

        public ActivityTypeEntity(long? id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
