using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Diplom.Resources.Model
{
    public class UserEntity
    {
        public long? id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public PersonEntity person { get; set; }
        public RoleEntity role { get; set; }

        public UserEntity()
        {
            person = new PersonEntity();
            role = new RoleEntity();
        }

        public static implicit operator UserControl(UserEntity v)
        {
            throw new NotImplementedException();
        }
    }
}
