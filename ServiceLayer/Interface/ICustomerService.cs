using EntityModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface ICustomerService
    {
        public UserInfo getUserInfo(int userID);
        public string getGreetings(UserInfo userInfo);
    }
}
