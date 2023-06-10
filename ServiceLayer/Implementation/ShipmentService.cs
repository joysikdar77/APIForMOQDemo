using DataLayer.Interface;
using EntityModelLayer.Entity;
using Microsoft.Extensions.Logging;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentActions _actions;
        private readonly ILogger _logger;
        public ShipmentService(IShipmentActions shipmentActions,ILogger logger) {
            _actions = shipmentActions;
            _logger = logger;
        }
        public void Ship(AddressInfo info, IEnumerable<CartItem> items)
        {
            _logger.Log(LogLevel.Information, string.Format("Shipped items {0} to address {1}",items, info));
            _actions.Ship(info, items);
        }
    }
}
