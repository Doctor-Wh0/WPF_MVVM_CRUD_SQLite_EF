using BellIntegratorTestTask.DAL.Interfaces;
using BellIntegratorTestTask.Core.Models;

namespace BellIntegratorTestTask.DAL
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository)
            : base(repository)
        {

        }
    }
}
