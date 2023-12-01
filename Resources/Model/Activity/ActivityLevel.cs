using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model.Activity
{
    public class ActivityLevel
    {
        public int id { get; set; }
        public string name { get; set; }

        public ActivityLevel()
        {
            
        }

        public ActivityLevel(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
