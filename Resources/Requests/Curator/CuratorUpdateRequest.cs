using Diplom.Resources.Model;
using Diplom.Resources.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Curator
{
    public class CuratorUpdateRequest
    {
        public long id { get; set; }
        public UserUpdateRequest user { get; set; }
        public long groupId { get; set; }

        public CuratorUpdateRequest(CuratorEntity curator)
        {
            id = curator.id.Value;
            user = new UserUpdateRequest(curator.user);
            groupId = curator.group.id.Value;
        }
    }
}
