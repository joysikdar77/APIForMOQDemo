using EntityModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface IShipmentActions
    {
        void Ship(AddressInfo info, IEnumerable<CartItem> items);
    }
}
