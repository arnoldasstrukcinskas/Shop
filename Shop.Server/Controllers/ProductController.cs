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
        [HttpPost]
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
        public async Task<IActionResult> GetAllProduts()
        {
            try
            {
                List<ProductDto> products = await _productService.GetAllProducts();
                return Ok(products);
            } 
            catch
            {
                return BadRequest("Something went wrong");
            }

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
    }
}
