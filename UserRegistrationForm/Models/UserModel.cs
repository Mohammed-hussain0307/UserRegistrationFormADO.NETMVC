using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserRegistrationForm.Models
{
	public class UserModel
	{
		[Key]
		public int Id { get; set; }

		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[Required]
	        [DisplayName("Last Name")]
	        public string LastName { get; set; }
	
	        [StringLength(10)]
	        [DisplayName("Date of Birth")]
	        public string DataOfBirth { get; set; }
	
	        [DisplayName("Gender")]
	        public string Gender { get; set; }
	
		[Required]
	        [StringLength(10)]
	        [DisplayName("Mobile Number")]
	        public string MobileNumber { get; set; }

		[Required]
		[EmailAddress]
	        [DisplayName("Email Address")]
	        public string EmailAddress { get; set; }
	
	        [DisplayName("Address")]
	        [StringLength(200)]
		public string Address { get; set; }
	
	        [DisplayName("City")]
	        public string City { get; set; }
	
	        [DisplayName("State")]
	        public string State { get; set; }
	
	        [DisplayName("User Name")]
	        [Required]
		public string UserName { get; set; }
	
	        [DisplayName("Password")]
	        [Required]
		public string PassWord { get; set; }
	}
}
