using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model
{
    public class Curator 
    {
        public long? id { get; set; }
        public User user { get; set; }
        public Group group { get; set; }

        public Curator()
        {
            user = new User();
            group = new Group();
        }
    }
}
