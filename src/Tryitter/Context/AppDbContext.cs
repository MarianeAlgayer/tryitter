using System;
using Microsoft.EntityFrameworkCore;
using Tryitter.Models;

namespace Tryitter.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{}

		public DbSet<Post>? Posts { get; set; }
        public DbSet<StudentAccount>? StudentAccounts { get; set; }
    }
}
