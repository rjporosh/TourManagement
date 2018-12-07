using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TourManagementApps.Models
{
    public class AgentInquiry
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Company Name")]
        [Required]
        public string CompanyName { get; set; }

        [DisplayName("Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }


        public int CountryId { get; set; }
        public virtual Country Country { get; set; }



        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }

        [DisplayName("Name")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Comments")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        
    }
}