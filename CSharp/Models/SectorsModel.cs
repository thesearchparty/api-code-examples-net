using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Models
{
    public class SectorsModel
    {
        public IEnumerable<SelectListItem> Sectors {get; set;}

        public List<Sector> SubSectors { get; set; }

        public int SectorId { get; set; }

        public string RawOutput { get; set; }
       
    }
}