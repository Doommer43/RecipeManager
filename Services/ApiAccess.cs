using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException("This needs fixin'. Get to it!");
        }
    }
}
