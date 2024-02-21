using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model
{
    public class StudentEntity
    {
        public int? id { get; set; }
        public string? registrationAddress { get; set; }
        public string? residentialAddress { get; set; }
        public string? phone { get; set; }
        public EducationFormEntity? educationForm { get; set; }
        public UserEntity? user { get; set; }
        public GroupEntity? group { get; set; }

        public StudentEntity()
        {
            user = new UserEntity();
        }
    }
}
