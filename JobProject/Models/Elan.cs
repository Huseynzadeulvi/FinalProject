using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobProject.Models
{
    public class Elan
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(500)]
        public string JobDescription { get; set; }

        public int JobTypeId { get; set; }

        public virtual JobType JobType { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}