using EntityModelLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;

namespace APIForMOQDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly IShipmentService _shipmentService;
        private readonly ICustomerService _customerService;
        private readonly ICleanUserService _cleanUserService;
        public CartController(ICartService cartService, IPaymentService paymentService, IShipmentService shipmentService, ICustomerService customerService, ICleanUserService cleanUserService)
        {
            _cartService = cartService;
            _paymentService = paymentService;
            _shipmentService = shipmentService;
            _customerService = customerService;
            _cleanUserService = cleanUserService;
        }

        [HttpPost]
        public string CheckOut(CardInfo card, AddressInfo addressInfo)
        {
            var result = _paymentService.Charge(_cartService.Total(), card);
            if (result)
            {
                _shipmentService.Ship(addressInfo, _cartService.Items());
                return "charged";
            }
            else
            {
                return "not charged";
            }
        }

        [HttpGet]
        public string GetUserGreetings(UserInfo userInfo)
        {
            _cleanUserService.Clean(userInfo);
            return string.Format("Welcome {0} {1}", userInfo.FirstName, userInfo.LastName);
        }

        public UserInfo GetUserInfo(int userID)
        {
            return _customerService.getUserInfo(userID);
        }
    }
}
