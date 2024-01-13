using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Person
{
    public class PersonCreateRequest
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }

        public PersonCreateRequest(PersonEntity person)
        {
            this.surname = person.surname;
            this.name = person.name;
            this.patronymic = person.patronymic;
        }
    }
}
