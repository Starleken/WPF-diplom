using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Inn
{
    internal class InnCreateRequest
    {
        public string number { get; set; }
        public long studentId { get; set; }

        public InnCreateRequest(InnEntity inn)
        {
            this.number = inn.number;
            this.studentId = inn.student.id.Value;
        }
    }
}
