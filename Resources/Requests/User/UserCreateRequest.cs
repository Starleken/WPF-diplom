using Diplom.Resources.Model;
using Diplom.Resources.Requests.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.User
{
    public class UserCreateRequest
    {
        public string login { get; set; }
        public string password { get; set; }
        public long roleId { get; set; }
        public PersonCreateRequest person {  get; set; }

        public UserCreateRequest(UserEntity user)
        {
            this.login = user.login;
            this.password = user.password;
            this.roleId = user.role.id.Value;
            this.person = new PersonCreateRequest(user.person);
        }
    }
}
