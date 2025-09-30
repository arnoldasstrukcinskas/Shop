using shop.DATA.Entities;
using shop.DATA.Repositories.Interfaces;
using Shop.BLL.DTO;
using Shop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> AddProductAsync(ProductDto productDto)
        {
            Product product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Image = productDto.Image,
                Description = productDto.Description
            };

            await _productRepository.AddProductAsync(product);

            return productDto;
            
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            List<Product> products = await _productRepository.GetAllProducts();
           
            if(products == null)
            {
                throw new Exception("Products was not found");
            }

            List<ProductDto> responseProducts = new List<ProductDto>();

            products.ForEach(product =>
            {
                responseProducts.Add(new ProductDto
                {
                    Name = product.Name,
                    Price = product.Price,
                    Image = product.Image,
                    Description = product.Description
                });
            });

            return responseProducts;

        }

        public async Task<ProductDto> GetProductByName(string name)
        {
            Product product = await _productRepository.GetProductByName(name);

            ProductDto returnProduct = new ProductDto {
            Name = product.Name,
            Price = product.Price,
            Image = product.Image,
            Description = product.Description
            };
            return returnProduct;
        }
    }
}
