using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts
{
    class ProfileNotification
    {
        public int number { get; set; }
        public string description { get; set; }

        public ProfileNotification(int number, string description)
        {
            this.number = number;
            this.description = description;
        }
    }
}
