using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model
{
    class FluVaccine
    {
        public long? id { get; set; }
        public DateTime createDate { get; set; }
        public Student student { get; set; }
        public string imageURL { get; set; }
    }
}
