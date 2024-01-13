using Diplom.Resources.Model;
using Diplom.Resources.Requests.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.User
{
    public class UserUpdateRequest
    {
        public long id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public long roleId { get; set; }
        public PersonUpdateRequest person { get; set; }

        public UserUpdateRequest(UserEntity user)
        {
            this.id = user.id.Value;
            this.login = user.login;
            this.password = user.password;
            this.roleId = user.role.id.Value;
            person = new PersonUpdateRequest(user.person);
        }
    }
}
