using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class SkillsModel
    {
        public Guid? CandidateId { get; set; }

        public Skill Skill { get; set; }
         
        public string RawOutput { get; set; }

        public string ResponseCode { get; set; }
        
    }
}