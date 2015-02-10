using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class Skill
    {

        [DisplayName("Skill ID")]
        public Guid? Id { get; set; }

        [DisplayName("Candidate ID")]
        public Guid? CandidateId { get; set; }

        [DisplayName("Skill Name")]
        public string SkillName { get; set; }


        [DisplayName("Level")]
        public short? LevelId { get; set; }
        public int? Years { get; set; }

    }
}