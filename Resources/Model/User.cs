using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model
{
    public class User
    {
        public int? id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Person person { get; set; }
        public Role role { get; set; }

        public User()
        {
            person = new Person();
            role = new Role();
        }
    }
}
