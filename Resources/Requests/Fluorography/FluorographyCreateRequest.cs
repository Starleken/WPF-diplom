using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Fluorography
{
    class FluorographyCreateRequest
    {
        public string number { get; set; }
        public DateTime createDate { get; set; }
        public long? studentId { get; set; }

        public FluorographyCreateRequest(FluorographyEntity fluorography)
        {
            this.number = fluorography.number;
            this.createDate = fluorography.createDate;
            this.studentId = fluorography.student.id;
        }
    }
}
