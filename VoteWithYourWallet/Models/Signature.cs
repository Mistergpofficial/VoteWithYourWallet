using System;
using System.ComponentModel.DataAnnotations;

namespace VoteWithYourWallet.Models
{
	public class Signature
	{
        public int Id { get; set; }

        public string? UserId { get; set; }

        public int CauseId { get; set; }

        public string? Signer { get; set; }

        public DateTime SignedDate { get; set; }

        public string? Reason { get; set; }


    }
}

