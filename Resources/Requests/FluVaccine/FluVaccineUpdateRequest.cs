using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.FluVaccine
{
    internal class FluVaccineUpdateRequest
    {
        public long id { get; set; }
        public DateTime createDate { get; set; }

        public FluVaccineUpdateRequest(FluVaccineEntity fluVaccine)
        {
            this.id = fluVaccine.id.Value;
            this.createDate = fluVaccine.createDate;
        }
    }
}
