using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.FluVaccine
{
    internal class FluVaccineCreateRequest
    {
        public DateTime createDate { get; set; }
        public long studentId { get; set; }

        public FluVaccineCreateRequest(FluVaccineEntity fluVaccine)
        {
            this.createDate = fluVaccine.createDate;
            this.studentId = fluVaccine.student.id.Value;
        }
    }
}
