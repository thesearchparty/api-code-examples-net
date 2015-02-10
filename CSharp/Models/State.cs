using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class State
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string ShortTitle { get; set; }
        public string Title { get; set; }
    }
}