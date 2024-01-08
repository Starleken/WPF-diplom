using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Passport
{
    class PassportUpdateRequest
    {
        public long id;
        public string series;
        public string number;

        public PassportUpdateRequest(PassportEntity passport)
        {
            this.id = passport.id.Value;
            this.series = passport.series;
            this.number = passport.number;
        }
    }
}
