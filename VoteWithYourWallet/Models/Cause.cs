using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VoteWithYourWallet.Models
{
    public class Cause
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Category { get; set; }

        public string? Image { get; set; }

        public int SignatureCount { get; set; }

        public int Goal { get; set; } 

        public string? Creator { get; set; }

        public string? TruncatedDescription
        {
            get
            {
                const int maxLength = 300; // Change this value to adjust the maximum length
                return Description?.Substring(0, Math.Min(Description.Length, maxLength));
            }
        }
        public ApplicationUser? User { get; set; }


        public ICollection<Signature>? signatures { get; set; }



    }
}

