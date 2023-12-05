using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Diplom.Resources.Model
{
    public class User
    {
        public long? id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Person person { get; set; }
        public Role role { get; set; }

        public User()
        {
            person = new Person();
            role = new Role();
        }

        public static implicit operator UserControl(User v)
        {
            throw new NotImplementedException();
        }
    }
}
