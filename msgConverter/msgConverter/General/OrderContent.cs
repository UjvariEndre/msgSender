using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msgConverter.General
{
    internal class OrderContent
    {
        public string api_key;
        public string sign;
        public string sign_type;
        public string symbol;
        public string timestamp;
        public string recv_window;
        public string content_type;

        public OrderContent(string api_key, string sign, string sign_type, string symbol, string timestamp, string recv_window, string content_type)
        {
            this.api_key = api_key;
            this.sign = sign;
            this.sign_type = sign_type;
            this.symbol = symbol;
            this.timestamp = timestamp;
            this.recv_window = recv_window;
            this.content_type = content_type;
        }
    }
}
