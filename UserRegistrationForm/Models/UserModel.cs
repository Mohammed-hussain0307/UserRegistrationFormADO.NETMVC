using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserRegistrationForm.Models
{
	public class UserModel
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public string DataOfBirth { get; set; }		
		public string Gender { get; set; }
		[Required]
        [StringLength(10)]
        public string MobileNumber { get; set; }
		[Required]
		public string EmailAddress { get; set; }
		[StringLength(200)]
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		public string PassWord { get; set; }
	}
}