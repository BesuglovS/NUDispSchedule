using System.Collections.Generic;

namespace NUDispSchedule.wnu
{
    public class WNURequest
    {
        public Dictionary<string, string> Parameters { get; set; }
        
        public WNURequest()
        {
        }

        public WNURequest(Dictionary<string, string> parameters)
        {
            Parameters = parameters;
        }

        public string ToJSON()
        {
            var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            var json = jsonSerializer.Serialize(this);

            return json;
        }
    }
}
