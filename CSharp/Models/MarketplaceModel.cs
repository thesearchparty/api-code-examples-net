using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class MarketplaceModel
    {
        public Guid? CandidateId { get; set; }

        public string RawOutput { get; set; }

        public string ResponseCode { get; set; }
        
    }
}