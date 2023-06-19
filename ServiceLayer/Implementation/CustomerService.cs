using DataLayer.Interface;
using EntityModelLayer.Entity;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerAction _customerAction;
        private readonly ICleanUserService _cleanUserService;
        public CustomerService(ICustomerAction customerAction,ICleanUserService cleanUserService) { 
            _customerAction = customerAction;
            _cleanUserService = cleanUserService;
        
        }

        public string getGreetings(UserInfo userInfo)
        {
            _cleanUserService.Clean(userInfo);
            return string.Format( "Welcome {0} {1}",userInfo.FirstName,userInfo.LastName );
        }

        public UserInfo getUserInfo(int userID)
        {
            return _customerAction.getUserInfo(userID);
        }
    }
}
