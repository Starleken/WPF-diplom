using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.Exeptions
{
    internal class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
              
        }
    }
}
