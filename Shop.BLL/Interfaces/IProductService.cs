using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> AddProductAsync(ProductDto productDto);
        Task<ProductDto> GetProductById(int id);
        Task<List<ProductDto>> GetAllProducts();
        Task<List<ProductDto>> AddListOfProducts(List<ProductDto> producstDto);
    }
}
