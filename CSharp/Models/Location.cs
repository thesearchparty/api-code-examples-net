using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string LocationShort { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateId { get; set; }
        public string Postcode   { get; set; }
        public string CountryId   { get; set; }
        public string LocationLatLong   { get; set; }

    }
}