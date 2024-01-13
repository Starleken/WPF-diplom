using Diplom.Resources.Model;
using Diplom.Resources.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Student
{
    public class StudentCreateRequest
    {
        public long groupId { get; set; }
        public long educationFormId { get; set; }
        public UserCreateRequest user { get; set; }

        public StudentCreateRequest(StudentEntity student)
        {
            this.groupId = student.group.id.Value;
            this.educationFormId = student.educationForm.id.Value;
            user = new UserCreateRequest(student.user);
        }
    }
}
