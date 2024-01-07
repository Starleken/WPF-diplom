using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model
{
    class FluVaccineEntity
    {
        public long? id { get; set; }
        public DateTime createDate { get; set; }
        public StudentEntity student { get; set; }
        public string imageURL { get; set; }
    }
}
