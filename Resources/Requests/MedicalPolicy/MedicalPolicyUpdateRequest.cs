using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.MedicalPolicy
{
    internal class MedicalPolicyUpdateRequest
    {
        public long id { get; set; }
        public string number { get; set; }
        public string issuingOrganization { get; set; }

        public MedicalPolicyUpdateRequest(MedicalPolicyEntity medicalPolicy)
        {
            this.id = medicalPolicy.id.Value;
            this.number = medicalPolicy.number;
            this.issuingOrganization = medicalPolicy.issuingOrganization;
        }
    }
}
