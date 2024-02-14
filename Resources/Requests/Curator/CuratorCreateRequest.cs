using Diplom.Resources.Model;
using Diplom.Resources.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Requests.Curator
{
    public class CuratorCreateRequest
    {
        public UserCreateRequest user { get; set; }
        public long groupId { get; set; }

        public CuratorCreateRequest(CuratorEntity curator)
        {
            user = new UserCreateRequest(curator.user);
            groupId = curator.group.id.Value;
        }
    }
}
