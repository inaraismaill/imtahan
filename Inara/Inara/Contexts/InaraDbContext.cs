using Inara.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inara.Contexts
{
	public class InaraDbContext:IdentityDbContext
	{
		public InaraDbContext(DbContextOptions options) : base(options) { }
		public DbSet<Service> Services { get; set; }

	}
}
