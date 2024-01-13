using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Person
{
    public class PersonUpdateRequest
    {
        public long id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }

        public PersonUpdateRequest(PersonEntity person)
        {
            this.id = person.id.Value;
            this.surname = person.surname;
            this.name = person.name;
            this.patronymic = person.patronymic;
        }
    }
}
