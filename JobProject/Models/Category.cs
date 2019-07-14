using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobProject.Models
{
    public class Category
    {
        public Category()
        {
            Vakansiyas = new HashSet<Vakansiya>();
        }
        public int Id { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public string CategoryIcon { get; set; }

        public virtual IEnumerable<Vakansiya> Vakansiyas { get; set; }
    }
}