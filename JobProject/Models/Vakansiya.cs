using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobProject.Models
{
    public class Vakansiya
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string VakAd { get; set; }

        [StringLength(50)]
        public string VakSeher { get; set; }

        [StringLength(50)]
        public string VakSirket { get; set; }

        [StringLength(80)]
        public string VakMaas { get; set; }

        [StringLength(50)]
        public string VakDate { get; set; }

        [DataType(DataType.Text)]
        public string VakHaqqinda { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int Active { get; set; }
    }
}