using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Snils
{
    internal class SnilsUpdateRequest
    {
        public long id { get; set; }
        public string number { get; set; }

        public SnilsUpdateRequest(SnilsEntity snils)
        {
            this.id = snils.id.Value;
            this.number = snils.number;
        }
    }
}
