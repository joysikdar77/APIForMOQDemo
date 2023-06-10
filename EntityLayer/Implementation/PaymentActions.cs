using DataLayer.Interface;
using EntityModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class PaymentActions : IPaymentActions
    {
        public bool Charge(double total, CardInfo card)
        {
            throw new NotImplementedException();
        }
    }
}
