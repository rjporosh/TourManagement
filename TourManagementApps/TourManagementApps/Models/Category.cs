﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourManagementApps.Models
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required]
        public string CategoryName { get; set; }

        public virtual IEnumerable<TourPackage> TourPackages { get; set; }
    }
}