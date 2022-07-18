using msgConverter.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace msgConverter
{
    internal class Globals
    {
        public static Globals Instance { get; set; }
        static Globals()
        {
            Instance = new Globals();
        }
        public async Task StartUp()
        {
            //ByBitController.CreateOrder().GetAwaiter().GetResult();
            ByBitController.GetAvailableBalance().GetAwaiter().GetResult();
            Asd();
        }

        public void Asd()
        {
            //MailRepository.ConfigureClient();
        }
    }
}
