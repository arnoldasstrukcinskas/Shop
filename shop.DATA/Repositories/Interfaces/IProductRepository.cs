using shop.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.DATA.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product product);
        Task<Product> GetProductByName(string name);
        Task<List<Product>> GetAllProducts();
    }
}
