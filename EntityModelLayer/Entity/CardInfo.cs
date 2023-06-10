using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelLayer.Entity
{
    public class CardInfo
    {
        public string CardNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime ValidTo { get; set; }
    }
}
