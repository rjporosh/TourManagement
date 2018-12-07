using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourManagementApps.Models
{
    public class TourInquiry
    {
        public int Id { get; set; }

        public int TourPackageId { get; set; }
        public virtual TourPackage TourPackage { get; set; }



        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Contact No")]
        [Required]
        public string ContactNo { get; set; }

        [DisplayName("Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Comments")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }


    }
}