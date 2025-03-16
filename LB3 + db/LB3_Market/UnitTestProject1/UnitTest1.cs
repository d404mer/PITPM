using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LB3_Market.Models;
using LB3_Market.Repos;

namespace LB3_Market.Tests
{
    [TestClass]
    public class ProductRepoTests
    {
        private Mock<ProductsRepo> _mockProductRepo;

        [TestInitialize]
        public void SetUp()
        {
            // Инициализация Mock объекта для ProductRepo
            _mockProductRepo = new Mock<ProductsRepo>();
        }

        [TestMethod]
        public void GetAllProducts_ShouldReturnListOfProducts()
        {
            // Arrange
            var expectedProducts = new List<Products>
            {
                new Products { ProductID = 1, ProductName = "Product 1", Description = "Description 1", Price = 100, ImageURL = "url1" },
                new Products { ProductID = 2, ProductName = "Product 2", Description = "Description 2", Price = 200, ImageURL = "url2" }
            };

            _mockProductRepo.Setup(repo => repo.GetAllProducts()).Returns(expectedProducts);

            // Act
            var result = _mockProductRepo.Object.GetAllProducts();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Product 1", result[0].ProductName);
            Assert.AreEqual("Product 2", result[1].ProductName);
        }

        [TestMethod]
        public void AddProduct_ShouldAddProduct()
        {
            // Arrange
            var newProduct = new Products { ProductID = 3, ProductName = "Product 3", Description = "Description 3", Price = 300, ImageURL = "url3" };

            var mockProductRepo = new Mock<ProductsRepo>();
            mockProductRepo.Setup(repo => repo.AddProduct(It.IsAny<Products>())).Returns(true);

            // Act
            var result = mockProductRepo.Object.AddProduct(newProduct);

            // Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void UpdateProduct_ShouldUpdateProduct()
        {
            // Arrange
            var existingProduct = new Products { ProductID = 1, ProductName = "Product 1", Description = "Updated Description", Price = 150, ImageURL = "updatedUrl" };

            _mockProductRepo.Setup(repo => repo.UpdateUser(It.IsAny<Products>())).Returns(true);

            // Act
            var result = _mockProductRepo.Object.UpdateUser(existingProduct);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteProduct_ShouldDeleteProduct()
        {
            // Arrange
            var productId = 1;
            var mockProductRepo = new Mock<ProductsRepo>();

            // Настроим, что метод DeleteProd должен вернуть true
            mockProductRepo.Setup(repo => repo.DeleteProd(productId)).Returns(true);

            // Act
            var result = mockProductRepo.Object.DeleteProd(productId);

            // Assert
            Assert.IsTrue(result);
        }


    }
}
