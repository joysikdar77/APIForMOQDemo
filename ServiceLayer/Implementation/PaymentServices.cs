using EntityModelLayer.Entity;
using ServiceLayer.Interface;
using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Implementation;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.Implementation
{
    public class PaymentServices : IPaymentService
    {
        private readonly IPaymentActions _action;
        private readonly ILogger _logger;
        public PaymentServices(IPaymentActions paymentActions,ILogger logger) {
            _action = paymentActions;
            _logger = logger;
        }
        public bool Charge(double total, CardInfo card)
        {
            var result = _action.Charge(total, card);
            if(result)
            {
                _logger.Log(LogLevel.Information, string.Format("Total Payment of {0} is Done useing card {1}", total, card.CardNumber));
                return result;
            }
            return false;
        }
    }
}
