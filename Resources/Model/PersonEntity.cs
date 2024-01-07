using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Diplom.Resources.Model
{
    public class PersonEntity
    {
        public int? id { get; set; }
        public string name { get; set;}
        public string surname { get; set; }
        public string patronymic { get; set; }

        public string FullName => $"{surname} {name}";
        public string FullName1 => $"{surname} {name} {patronymic}";
        public string Initials => $"{surname[0]}{name[0]}";
    }
}
