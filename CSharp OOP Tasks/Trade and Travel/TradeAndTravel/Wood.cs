using System;
using System.Collections.Generic;
using System.Linq;

namespace TradeAndTravel
{
    class Wood : Item
    {
        private const int WOOD_INITIAL_VALUE = 2;

        public Wood(string name,  Location location = null)
            :base(name, WOOD_INITIAL_VALUE, ItemType.Wood, location)
        { }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 0)
            {
                this.Value--;
            }
        }
    }
}
