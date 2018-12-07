using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourManagementApps.Models
{
    public class TourPackage
    {
        public int Id { get; set; }

        [DisplayName("Agent Name")]
        [Required]
        public string AgentName { get; set; }

        [DisplayName("Agent No")]
        [Required]
        public string AgentNo { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        

        // FK
        public int PackageTypeId { get; set; }
        public virtual PackageType PackageType { get; set; }
        
        // FK
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        

        [DisplayName("Tour Place")]
        [Required]
        public string TourPlace { get; set; }

        [DisplayName("Days")]
        [Required]
        public string Days { get; set; }

        [DisplayName("Package Amount")]
        [Required]
        public string Amount { get; set; }


        public virtual IEnumerable<TourInquiry> TourInquiries { get; set; } 


    }
}