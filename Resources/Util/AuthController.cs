using Diplom.Resources.Model;
using Diplom.Resources.Scripts.Exeptions;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Scripts.Util
{
    class AuthController
    {
        public static UserEntity CurrentUser { get; private set; }

        public void AuthByLoginAndPassword(string login, string password)
        {
            UserRepository userRepository = new UserRepository();
            UserEntity user = userRepository.findByLoginAndPassword(login, password);

            if (user == null)
            {
                throw new AuthException("Неверный логин или пароль");
            }

            CurrentUser = user;
        }
    }
}
