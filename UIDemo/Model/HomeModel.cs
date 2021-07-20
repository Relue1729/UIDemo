using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIDemo.Common;
using UIDemo.Common.Interfaces;

namespace UIDemo.Model
{
    public class HomeModel : IModel
    {
        public IDictionary<string, string> Labels => new Dictionary<string, string>()
        {
            { "Weather",  "Погода"       },
            { "System",   "Система"      },
            { "Photo",    "Фотографии"   },
            { "Messages", "Сообщения"    },
            { "NewsTitle","Главные новости сегодня" }
        };
        public DateTime AlarmTime => new DateTime(2021,08,21,7,0,0);
        public async Task<List<string>> GetTopNewsHeaders()
        {
            var xmlElement = await ApiHandler.GetXmlFromApi("https://news.google.com/rss?hl=ru"); 
            return (from item in xmlElement.Descendants("item")
                    select (string)item.Element("title"))
                    .Take(15).ToList();
        }
    }
}