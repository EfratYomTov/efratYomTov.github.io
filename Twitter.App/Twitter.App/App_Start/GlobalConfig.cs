using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Twitter.App
{
    public class GlobalConfig
    {
        public static void Configure()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
        
    }
}