using Moq;
using shop.DATA.Entities;
using shop.DATA.Repositories.Interfaces;
using Shop.BLL.DTO;
using Shop.BLL.Interfaces;
using Shop.BLL.Services;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace shop.TEST
{
    public class ProductUnitTest
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly IProductService _productService;

        public ProductUnitTest()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockProductRepository.Object);
        }

        private readonly ProductDto testProductDTO = new ProductDto
        {
            Id = 1,
            Name = "Laptop",
            Price = 50,
            Image = "image.jpg",
            Description = "Very cool laptop"
        };

        private readonly Product testProduct = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 50,
            Image = "image.jpg",
            Description = "Very cool laptop"
        };

        private readonly List<Product> testProducts = new List<Product>()
{
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 50,
                Image = "image.jpg",
                Description = "Very cool laptop"
            },
            new Product
            {
                Id = 2,
                Name = "Tablet",
                Price = 30,
                Image = "tablet.jpg",
                Description = "Very cool tablet"
            },
            new Product
            {
                Id = 3,
                Name = "Phone",
                Price = 20,
                Image = "phone.jpg",
                Description = "Very cool phone"
            }
        };

        private readonly List<Product> testProductsDTO = new List<Product>()
{
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 50,
                Image = "image.jpg",
                Description = "Very cool laptop"
            },
            new Product
            {
                Id = 2,
                Name = "Tablet",
                Price = 30,
                Image = "tablet.jpg",
                Description = "Very cool tablet"
            },
            new Product
            {
                Id = 3,
                Name = "Phone",
                Price = 20,
                Image = "phone.jpg",
                Description = "Very cool phone"
            }
        };

        [Fact]
        public async Task TestAddProduct()
        {
            _mockProductRepository.Setup(service => service.AddProductAsync(testProduct))
    .ReturnsAsync(testProduct);

            var response = await _productService.AddProductAsync(testProductDTO);
            Assert.NotNull(response);
            Assert.Equal(1, response.Id);
            Assert.Equal("Laptop", response.Name);
            Assert.Equal(50, response.Price);
            Assert.Equal("image.jpg", response.Image);
            Assert.Equal("Very cool laptop", response.Description);
        }

        [Fact]
        public async Task TestGetProductById()
        {
            _mockProductRepository.Setup(service => service.GetProductById(testProduct.Id))
                .ReturnsAsync(testProduct);

            var response = await _productService.AddProductAsync(testProductDTO);

            Assert.NotNull(response);
            Assert.Equal(1, response.Id);
            Assert.Equal("Laptop", response.Name);
            Assert.Equal(50, response.Price);
            Assert.Equal("image.jpg", response.Image);
            Assert.Equal("Very cool laptop", response.Description);

        }

        [Fact]
        public async Task TestGetAllProducts()
        {
            _mockProductRepository.Setup(service => service.GetAllProducts())
                .ReturnsAsync(testProducts);

            var response = await _productService.GetAllProducts();

            Assert.NotNull(response);
            Assert.Equal(3, response.Count());
            for (int i = 0; i < testProducts.Count; i++)
            {
                Assert.Equal(testProducts[i].Id, testProductsDTO[i].Id);
                Assert.Equal(testProducts[i].Name, testProductsDTO[i].Name);
                Assert.Equal(testProducts[i].Price, testProductsDTO[i].Price);
                Assert.Equal(testProducts[i].Image, testProductsDTO[i].Image);
                Assert.Equal(testProducts[i].Description, testProductsDTO[i].Description);
            }
        }
    }
}