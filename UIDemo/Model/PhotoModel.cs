using System.Collections.Generic;
using UIDemo.Common.Interfaces;

namespace UIDemo.Model
{
    class PhotoModel : IModel
    {
        public IDictionary<string, string> Labels => new Dictionary<string, string>()
        {
            { "Title", "throw new NotImplementedException()" }
        };
    }
}
