using Microsoft.AspNetCore.Mvc;
using shop.DATA.Entities;
using Shop.BLL.DTO;
using Shop.BLL.Interfaces;

namespace Shop.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Adds product to database
        /// </summary>
        /// <returns>A product object with name, price, image, description</returns>
        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            if(productDto == null)
            {
                return BadRequest("Product is empty");
            }

            try
            {
                var product = await _productService.AddProductAsync(productDto);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest("Something is wrong");
            }          
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProduts(int page = 1, int pageSize = 20)
        {
            List<ProductDto> products = await _productService.GetAllProducts();
            
            if (products == null)
            {
                throw new Exception("Controller: Failed to get products");
            }

            int totalItems = products.Count();

            List<ProductDto> responseList = products
                .OrderBy(product => product.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return Ok(new
            {
                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Data = responseList
            });
        }

        [HttpGet("product")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            try
            {
                ProductDto product = await _productService.GetProductByName(name);
                return Ok(product);
            }
            catch
            {
                return BadRequest("Something gone wrong");
            }
        }
        [HttpPost("addProducts")]
        public async Task<IActionResult> AddProducts(List<ProductDto> productsDto)
        {
            try
            {
                await _productService.AddListOfProducts(productsDto);
                return Ok(productsDto);
            }
            catch
            {
                return BadRequest("Controller: Products not added");
            }
        }
    }
}
