using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msgConverter.Object
{
    internal class GetBalanceHeaderObject
    {
        public string apiTimestamp;
        public string apiKey;
        public string apiSignature;
        public GetBalanceHeaderObject(string apiTimestamp, string apiKey, string apiSignature)
        {
            this.apiTimestamp = apiTimestamp;
            this.apiKey = apiKey;
            this.apiSignature = apiSignature;
        }
    }
}
