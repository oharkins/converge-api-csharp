using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oharkins
{
    
    public class TransactionError : Exception
    {
        public string errMessage { get; set; }
        public string errCode { get; set; }
        public string errName { get; set; }

        public TransactionError(string message) : base(message)
        {
        }
    }
    
}
