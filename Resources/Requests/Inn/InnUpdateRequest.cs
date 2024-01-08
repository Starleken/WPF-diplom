using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Inn
{
    internal class InnUpdateRequest
    {
        public long id { get; set; }
        public string number { get; set; }

        public InnUpdateRequest(InnEntity inn)
        {
            this.id = inn.id.Value;
            this.number = inn.number;
        }
    }
}
