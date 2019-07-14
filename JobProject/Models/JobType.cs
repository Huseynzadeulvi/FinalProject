using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobProject.Models
{
    public class JobType
    {
        public JobType()
        {
            Elans = new HashSet<Elan>();
        }
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual IEnumerable<Elan> Elans { get; set; }
    }
}