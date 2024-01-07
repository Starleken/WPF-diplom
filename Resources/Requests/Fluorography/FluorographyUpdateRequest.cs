using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Fluorography
{
    class FluorographyUpdateRequest
    {
        public long id { get; set; }
        public string number { get; set; }
        public DateTime createDate { get; set; }

        public FluorographyUpdateRequest(FluorographyEntity fluorography)
        {
            this.id = fluorography.id.Value;
            this.number = fluorography.number;
            this.createDate = fluorography.createDate;
        }
    }
}
