using System.Collections.Generic;
using UIDemo.Common.Interfaces;

namespace UIDemo.Model
{
    class SystemModel : IModel
    {
        public IDictionary<string, string> Labels => new Dictionary<string, string>()
        {
            { "CPU", "CPU" },
            { "RAM", "RAM" }
        };
    }
}