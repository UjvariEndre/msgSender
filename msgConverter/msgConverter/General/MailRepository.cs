using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using mailslurp.Api;
using mailslurp.Client;
using mailslurp.Model;

namespace msgConverter.General
{
    public class MailRepository
    {
        public static void ConfigureClient()
        {
            var config = new Configuration();
            config.ApiKey.Add("x-api-key", "9d4380d9cc500896ab8781ee325e26c755a9565addd069d48d29d0a7c1fca6ce");
            var apiInstance = new InboxControllerApi(config);
            var inbox = apiInstance.GetInboxByEmailAddress("9624ccd8-133c-4129-af71-2cf379b5c15e@mailslurp.mx");

            //var pageInboxes = apiInstance.GetAllInboxes(page: 0, size: 20);
            //Guid inboxId = pageInboxes.Content.First().Id;
            //var waitController = new WaitForControllerApi(config);
            //waitController.WaitForLatestEmail(inboxId: inboxId, timeout: 30_000);
            var list = apiInstance.GetInboxEmailsPaginated(inbox.InboxId);


            //var Timeout = 30000L; // max milliseconds to wait
            //var UnreadOnly = true; // only count unread emails
            //var waitForInstance = new WaitForControllerApi(config);
            //var email = waitForInstance.WaitForLatestEmail(inboxId, Timeout, UnreadOnly);
            //var rx = new Regex(@"Your code is: ([0-9]{3})", RegexOptions.Compiled);
            //var match = rx.Match(email.Body);
            //var code = match.Groups[1].Value;

        }
    }
}
