using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ApiAccess
    {
        private string endPoint;

        public ApiAccess(string endPoint)
        {
            this.endPoint = endPoint;
        }

        public string EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public string GetApiResponse(string queryString)
        {
            using (WebClient client = new WebClient())
            {
                string content = client.DownloadString(EndPoint+queryString);

                var res = JObject.Parse(content);

                var entities = (JObject)res["query"]["pages"];

                var entity = entities.Properties().First();

                var pageValues = (JObject)entity.Value;

                var pageValue = pageValues["extract"];

                return pageValue.ToString();
            }
        }
    }
}
