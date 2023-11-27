using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model
{
    public class Student
    {
        public int id { get; set; }
        public string? registrationAddress { get; set; }
        public string? residentialAddress { get; set; }
        public EducationForm? educationForm { get; set; }
        public User? user { get; set; }
        public Group? group { get; set; }

        public Student()
        {
            user = new User();
        }
    }
}
