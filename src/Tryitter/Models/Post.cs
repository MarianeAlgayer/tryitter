using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Models
{
	[Table("Posts")]
	public class Post
	{
		[Key]
		public int PostId { get; set; }

		[Required]
		[StringLength(300)]
		public string Text { get; set; }

        [StringLength(300)]
        public string? ImageUrl { get; set; }

		public DateTime PostDate { get; set; }

		public int StudentAccountId { get; set; }
		public StudentAccount? StudentAccount { get; set; }
	}
}
