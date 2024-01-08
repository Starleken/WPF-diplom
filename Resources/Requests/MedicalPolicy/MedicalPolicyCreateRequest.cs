using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.MedicalPolicy
{
    internal class MedicalPolicyCreateRequest
    {
        public string number { get; set; }
        public long studentId { get; set; }

        public MedicalPolicyCreateRequest(MedicalPolicyEntity medicalPolicy)
        {
            this.number = medicalPolicy.number;
            this.studentId = medicalPolicy.student.id.Value;
        }
    }
}
