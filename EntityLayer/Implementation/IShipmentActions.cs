using DataLayer.Interface;
using EntityModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class ShipmentActions : IShipmentActions
    {
        public void Ship(AddressInfo info, IEnumerable<CartItem> items)
        {
            throw new NotImplementedException();
        }
    }
}
