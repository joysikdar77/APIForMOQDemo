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
    public class CartService : ICartService
    {
        private readonly ICartActions _actions;
        public CartService( ICartActions cartActions) { 
            _actions = cartActions;
        }

        public IEnumerable<CartItem> Items()
        {
            return _actions.Items();
        }

        public double Total()
        {
            return _actions.Total();
        }
    }
}
