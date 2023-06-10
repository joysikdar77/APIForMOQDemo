using DataLayer.Interface;
using EntityModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class CartActions : ICartActions
    {
        public IEnumerable<CartItem> Items()
        {
            throw new NotImplementedException();
        }

        public double Total()
        {
            throw new NotImplementedException();
        }
    }
}
