using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProject.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Category> Category { get; set; }
        public List<Elan> Elan { get; set; }
    }
}