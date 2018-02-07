using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.Manager
{
    class LoginManager
    {
        LoginGateway aLoginGateway = new LoginGateway();

        public bool CheckLogin(User aUser)
        {
            return aLoginGateway.CheckLogin(aUser);
        }
    }
}
