using EntityModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface ICartActions
    {
        double Total();
        IEnumerable<CartItem> Items();
    }
}
