using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Snils
{
    internal class SnilsCreateRequest
    {
        public string number { get; set; }
        public long studentId { get; set; }

        public SnilsCreateRequest(SnilsEntity snils)
        {
            this.number = snils.number;
            this.studentId = snils.student.id.Value;
        }
    }
}
