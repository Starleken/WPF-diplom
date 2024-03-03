using Diplom.Resources.Model;
using Diplom.Resources.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Student
{
    public class StudentUpdateRequest
    {
        public long id { get; set; }
        public string registrationAddress { get; set; }
        public string residentialAddress { get; set; }
        public string phone { get; set; }
        public long educationFormId { get; set; }
        public UserUpdateRequest user { get; set; }
        public long groupId { get; set; }

        public StudentUpdateRequest(StudentEntity student)
        {   
            this.id = student.id.Value;
            this.registrationAddress = student.registrationAddress;
            this.residentialAddress = student.residentialAddress;
            this.educationFormId = student.educationForm.id.Value;
            this.user = new UserUpdateRequest(student.user);
            this.groupId = student.group.id.Value;
            this.phone = student.phone;
        }
    }
}
