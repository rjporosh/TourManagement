using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourManagementApps.Models
{
    public class Country
    {
        public int Id { get; set; }

        [DisplayName("Country Name")]
        [Required]
        public string CountryName { get; set; }

        public virtual IEnumerable<AgentInquiry> AgentInquiries { get; set; }
    }
}