using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using msgConverter;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using RestSharp;
using Newtonsoft.Json;
using msgConverter.Object;

namespace msgConverter.General
{
    internal class ByBitController
    {
        //private const string url = "https://api.bybit.com/derivatives/v3/copytrading/order/create";
        private const string apiKey = "cO3N2CbG5jq9Sf4ogf";
        private const string apiSecret = "i9gXLzDg34s7lhmfpCgF0pPae7jHCkXYqOFr";
        
        public async static Task<string> CreateOrder()
        {
            var lurl = "https://api.bybit.com/derivatives/v3/copytrading/order/create";
            // Set up OrderData
            OrderData orderData = new OrderData("Buy", "BTCUSDT", "Market", "", "");
            string payload = JsonConvert.SerializeObject(orderData);
            string ts = GetServerTime().Result;
            string recv_window = "5000";
            string paramString = ts + apiKey + recv_window + payload;
            string sign = CreateSignature(apiSecret, paramString);

            OrderContent co = new OrderContent(apiKey, sign, "2", "BTCUSDT", ts, recv_window, "application/json");

            var client = new RestClient(lurl);
            var request = new RestRequest();
            request.AddJsonBody(co);

            var response = client.Post(request);
            Console.WriteLine(response.StatusCode.ToString() + "   " + response);
            Console.WriteLine(response.Content.ToString());
            return "";
        }

        public static string CreateSignature(string secret, string message)
        {
            var signatureBytes = Hmacsha256(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(message));

            return Encoding.Default.GetString(signatureBytes);
        }

        private static byte[] Hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            {
                return hash.ComputeHash(messageBytes);
            }
        }

        public async static Task<string> GetServerTime()
        {
            var lurl = "https://api-testnet.bybit.com";
            var client = new RestClient(lurl + "/v2/public/time");
            var request = new RestRequest();
            var response = client.Get(request);
            Console.WriteLine(response.StatusCode.ToString() + "   " + response);
            Console.WriteLine(response.Content.ToString());
            var data = JObject.Parse(response.Content);
            var timeNow = data.GetValue("time_now");
            var timeString = timeNow.ToString();
            return timeString;
        }

        public async static Task<string> GetAvailableBalance()
        {
            var ts = GetServerTime().GetAwaiter().GetResult();
            string query = $"api_key={apiKey}&recv_window=50000&timestamp={ts}";
            // var recv_window = "5000";
            // var paramString = ts + apiKey + recv_window;
            //var paramString = ts + apiKey + "5000";
            var sign = CreateSignature(apiSecret, query);
            var param = $"api_key={apiKey}&recv_window=50000&timestamp={ts}&sign={sign}";
            var lurl = "https://api.bybit.com/contract/v3/private/copytrading/wallet/balance" + "?" + param;
            //var ho = new GetBalanceHeaderObject(ts, apiKey, sign);
            //request.AddJsonBody(ho);
            var client = new RestClient(lurl);
            var request = new RestRequest();
            var response = client.Post(request);
            return "";
        }

        //public async static Task CalculateOrderSize()
        //{

        //}
    }
}
