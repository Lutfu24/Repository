using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Contexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> context): base(context)
	{
	}

    public DbSet<Product> Products { get; set; } = null!;
}
