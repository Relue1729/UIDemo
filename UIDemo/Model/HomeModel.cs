using System;
using System.Collections.Generic;
using System.Globalization;
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
            { "Weather",  "Weather" },
            { "System",   "System"  },
            { "Photos",   "Photos"  },
            { "Messages", "Messages"}
        };
        public DateTime AlarmTime => new DateTime(2021,08,21,7,0,0);
        public async Task<List<string>> GetTopNewsHeaders()
        {
            var cultureInfo = CultureInfo.CurrentUICulture;
            var xmlElement = await ApiHandler.GetXmlFromApi("https://news.google.com/rss?hl=" + cultureInfo.Name); 
            return (from item in xmlElement.Descendants("item")
                    select (string)item.Element("title"))
                    .Take(15).ToList();
        }
    }
}
