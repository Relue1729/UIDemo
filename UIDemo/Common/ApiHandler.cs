using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UIDemo.Common
{
    public static class ApiHandler
    {
        public static async Task<string> GetStringFromApi(string apiLink)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(apiLink);
            }
        }
        public static async Task<dynamic> GetDynamicJObjectFromApi(string apiLink)
        {
            var apiResponce = await GetStringFromApi(apiLink);
            return (dynamic)JObject.Parse(apiResponce);
        }
        public static async Task<XElement> GetXmlFromApi(string apiLink)
        {
            var apiResponce = await GetStringFromApi(apiLink);
            return XElement.Parse(apiResponce);
        }
    }
}