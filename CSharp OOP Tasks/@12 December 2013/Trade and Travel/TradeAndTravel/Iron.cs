using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class Iron : Item
    {
        private const int IRON_INITIAL_VALUE = 3;

        public Iron(string name,  Location location = null)
            :base(name, IRON_INITIAL_VALUE, ItemType.Iron, location)
        { }

        
    }
}
