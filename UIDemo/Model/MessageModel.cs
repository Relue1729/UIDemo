using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIDemo.Common;
using UIDemo.Common.Interfaces;

namespace UIDemo.Model
{
    class MessageModel : IModel
    {
        public IDictionary<string, string> Labels => new Dictionary<string, string>()
        {
            { "Messages", "Messages" },
            { "From",     "From"     }
        };
        public struct Message
        {
            public string   Body        { get; }
            public string   FromUser    { get; }
            public DateTime ArrivalTime { get; }
            public Message(string Body, string FromUser, DateTime ArrivalTime)
            {
                this.Body        = Body;
                this.FromUser    = FromUser;
                this.ArrivalTime = ArrivalTime;
            }
        }
        public async Task<List<Message>> GetRandomQuotesAsMessages()
        {
            var messages = new List<Message>();
            var apiResponce = await ApiHandler.GetDynamicJObjectFromApi("https://quotable.io/quotes?limit=15");

            foreach (var message in apiResponce.results)
            {
                messages.Add(new Message((string)message.content, (string)message.author, DateTime.Now));
            }

            return messages;
        }
    }
}