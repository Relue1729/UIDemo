using System.Collections.Generic;

namespace UIDemo.Common.Interfaces
{
    interface IModel
    {
        IDictionary<string, string> Labels { get; }
    }
}