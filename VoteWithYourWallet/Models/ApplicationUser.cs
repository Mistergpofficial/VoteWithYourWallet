using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VoteWithYourWallet.Models
{
	public class ApplicationUser : IdentityUser
	{
		public String? FirstName { get; set; }
		public String? LastName { get; set; }



    }
}

