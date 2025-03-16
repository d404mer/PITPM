using LB3_Market.Models;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    class ProductServiceTests
    {
        private Mock<IProductRepository> _mockProductRepository;
        private ProductService _productService;

        [SetUp]
        public void SetUp()
        {
            // Инициализация Moq объекта
            _mockProductRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockProductRepository.Object);
        }

        [Test]
        public void GetAllProducts_ShouldReturnListOfProducts()
        {
            // Arrange: Подготовим данные для теста
            var mockProducts = new List<Products>
            {
                new Products { ProductID = 1, ProductName = "Product1", Description = "Description1", Price = 100, ImageURL = "url1" },
                new Products { ProductID = 2, ProductName = "Product2", Description = "Description2", Price = 200, ImageURL = "url2" }
            };

            // Настроим мок, чтобы возвращался список товаров
            _mockProductRepository.Setup(repo => repo.GetAllProducts()).Returns(mockProducts);

            // Act: Вызовем метод, который тестируем
            var result = _productService.GetAllProducts();

            // Assert: Проверим, что результат соответствует ожидаемому
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Product1", result[0].ProductName);
        }
    }
}
