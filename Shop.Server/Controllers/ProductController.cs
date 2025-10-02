using Microsoft.AspNetCore.Authorization;
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
        /// <param name="productDto">The data transfer object containing the details of the new product (name, price, image, description).</param>
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

        /// <summary>
        /// Route for geting projects from specified page
        /// </summary>
        /// <param name="page">Page number which sends front-end.</param>
        /// <param name="pageSize">Size of items in page</param>
        /// <returns>Returns set amount of products from given page</returns>
        [Authorize]
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

        /// <summary>
        /// Route for getting product by id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Returns product by given id</returns>
        [Authorize]
        [HttpGet("product")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                ProductDto product = await _productService.GetProductById(id);
                return Ok(product);
            }
            catch
            {
                return BadRequest("Something gone wrong");
            }
        }

        /// <summary>
        /// Method for testing to add lot of products
        /// </summary>
        /// <param name="productsDto">List of product data transfer object which contains (name, price, image, description). </param>
        /// <returns>Returns list of added products</returns>
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
