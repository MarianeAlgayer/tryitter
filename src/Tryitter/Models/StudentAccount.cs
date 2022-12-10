using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Models
{
    [Table("StudentAccounts")]
    public class StudentAccount
	{
        public StudentAccount()
        {
			Posts = new Collection<Post>();
        }

        [Key]
        public int StudentAccountId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(80)]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }

        [StringLength(15)]
        public string Status { get; set; }

        [Required]
        public int Module { get; set; }

		public ICollection<Post>? Posts { get; set; }
	}
}
