using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model
{
    public class CuratorEntity
    {
        public long? id { get; set; }
        public UserEntity user { get; set; }
        public GroupEntity group { get; set; }

        public CuratorEntity()
        {
            user = new UserEntity();
            group = new GroupEntity();
        }
    }
}
