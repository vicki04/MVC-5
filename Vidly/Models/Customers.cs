using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customers
    {

        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [Display(Name ="Date of Birth")]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name ="Membership Types")]
        public byte MembershipTypeId { get; set; }

    }
}