using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model
{
    public class Group
    {
        public long id { get; set; }
        public string name { get; set; }
        public Curator curator { get; set; }

        public Group()
        {
            curator = new Curator();
        }
    }
}
