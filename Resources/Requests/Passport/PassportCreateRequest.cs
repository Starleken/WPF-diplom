using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Passport
{
    class PassportCreateRequest
    {
        public string series { get; set; }
        public string number { get; set; }
        public long studentId { get; set; }

        public PassportCreateRequest(PassportEntity passport)
        {
            this.series = passport.series;
            this.number = passport.number;
            this.studentId = passport.student.id.Value;
        }
    }
}
