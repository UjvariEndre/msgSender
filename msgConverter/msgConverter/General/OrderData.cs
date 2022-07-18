using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msgConverter.General
{
    internal class OrderData
    {
        public string side;
        public string symbol;
        public string order_type;
        public string qty;
        public string price;
        public OrderData(string side, string symbol, string order_type, string qty, string price)
        {
            this.side = side;
            this.symbol = symbol;
            this.order_type = order_type;
            this.qty = qty;
            this.price = price;
        }
    }
}
