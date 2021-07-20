using System.Collections.Generic;
using UIDemo.Common.Interfaces;

namespace UIDemo.Model
{
    public class MainModel : IModel
    {
        public IDictionary<string, string> Labels => new Dictionary<string, string>()
        {
            { "HomeViewButton",     "Рабочий стол" },
            { "WeatherViewButton",  "Погода"       },
            { "SystemViewButton",   "Система"      },
            { "PhotoViewButton",    "Фотографии"   },
            { "MessagesViewButton", "Сообщения"    },
            { "ExitButton",         "Выход"        }
        };
    }
}