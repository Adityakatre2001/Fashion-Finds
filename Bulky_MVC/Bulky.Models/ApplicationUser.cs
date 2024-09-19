using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionFinds.Models {
	public class ApplicationUser:IdentityUser {
		[Required]
        public string Name { get; set; }

		public string? StreetAddress { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? PostalCode { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [ValidateNever]
        public Company? Company { get; set; } // it is called navigation property
        [NotMapped]
        public string Role { get; set; } // NotMapped annotation is used
                                           // to store the users role, but it is not stored in db
    }
}
