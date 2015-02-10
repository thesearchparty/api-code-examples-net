using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CSharp.Models
{
    public class SearchPartyWebResponse
    {
        public HttpStatusCode? StatusCode { get; set; }
        public string JsonString { get; set; }

    }
}