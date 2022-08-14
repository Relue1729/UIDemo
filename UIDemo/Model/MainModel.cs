using System.Collections.Generic;
using UIDemo.Common.Interfaces;

namespace UIDemo.Model
{
    public class MainModel : IModel
    {
        public IDictionary<string, string> Labels => new Dictionary<string, string>()
        {
            { "HomeViewButton",     "Main"    },
            { "WeatherViewButton",  "Weather" },
            { "SystemViewButton",   "System"  },
            { "PhotoViewButton",    "Photos"  },
            { "MessagesViewButton", "Messages"},
            { "ExitButton",         "Exit"    }
        };
    }
}