using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourManagementApps.Models
{
    public class PackageType
    {
        public int Id { get; set; }
        [DisplayName("Package Type Name")]
        [Required]
        public string PackageName { get; set; }

        public virtual IEnumerable<TourPackage> TourPackages { get; set; }

    }
}