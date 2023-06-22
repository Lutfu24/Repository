using Repository.Contexts;
using Repository.Models;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implamentations;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
