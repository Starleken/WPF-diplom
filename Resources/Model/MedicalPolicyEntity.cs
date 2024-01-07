using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model
{
    public class MedicalPolicyEntity
    {
        public long? id { get; set; }
        public string number { get; set; }
        public string imageURL { get; set; }
        public StudentEntity student { get; set; }
    }
}
