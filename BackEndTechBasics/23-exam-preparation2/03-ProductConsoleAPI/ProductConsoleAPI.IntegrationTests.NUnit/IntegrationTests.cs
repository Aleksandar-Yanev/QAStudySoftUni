using Microsoft.EntityFrameworkCore;
using ProductConsoleAPI.Business;
using ProductConsoleAPI.Business.Contracts;
using ProductConsoleAPI.Data.Models;
using ProductConsoleAPI.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace ProductConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestProductsDbContext dbContext;
        private IProductsManager productsManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestProductsDbContext();
            this.productsManager = new ProductsManager(new ProductsRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddProductAsync_ShouldAddNewProduct()
        {
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            var dbProduct = await this.dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == newProduct.ProductCode);

            Assert.NotNull(dbProduct);
            Assert.AreEqual(newProduct.ProductName, dbProduct.ProductName);
            Assert.AreEqual(newProduct.Description, dbProduct.Description);
            Assert.AreEqual(newProduct.Price, dbProduct.Price);
            Assert.AreEqual(newProduct.Quantity, dbProduct.Quantity);
            Assert.AreEqual(newProduct.OriginCountry, dbProduct.OriginCountry);
            Assert.AreEqual(newProduct.ProductCode, dbProduct.ProductCode);
        }

        //Negative test
        [Test]
        public async Task AddProductAsync_TryToAddProductWithInvalidCredentials_ShouldThrowException()
        {
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = -1m,
                Quantity = 100,
                Description = "Anything for description"
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await productsManager.AddAsync(newProduct));
            var actual = await dbContext.Products.FirstOrDefaultAsync(c => c.ProductCode == newProduct.ProductCode);

            Assert.IsNull(actual);
            Assert.That(ex?.Message, Is.EqualTo("Invalid product!"));

        }

        [Test]
        public async Task DeleteProductAsync_WithValidProductCode_ShouldRemoveProductFromDb()
        {
            // Arrange
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            // Act
            await productsManager.DeleteAsync(newProduct.ProductCode);
            var dbProduct = await this.dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == newProduct.ProductCode);

            // Assert
            Assert.IsNull(dbProduct);
        }

        [TestCase("  ")]
        [TestCase(null)]
        public async Task DeleteProductAsync_TryToDeleteWithNullOrWhiteSpaceProductCode_ShouldThrowException(string invalidProductCode)
        {
            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await productsManager.DeleteAsync(invalidProductCode));

            Assert.That(ex?.Message, Is.EqualTo("Product code cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenProductsExist_ShouldReturnAllProducts()
        {
            // Arrange
            var firstProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(firstProduct);

            var secondProduct = new Product()
            {
                OriginCountry = "Serbia",
                ProductName = "Second TestProduct",
                ProductCode = "AB13C",
                Price = 5.95m,
                Quantity = 9,
                Description = "Some description"
            };

            await productsManager.AddAsync(secondProduct);

            // Act
            var getAllProducts = await productsManager.GetAllAsync();

            // Assert
            Assert.NotNull(getAllProducts);
            Assert.That(getAllProducts.Count, Is.EqualTo(2));

            var firstReturnedProduct = getAllProducts.FirstOrDefault();
            var secondReturnedProduct = getAllProducts.LastOrDefault();

            Assert.AreEqual(firstProduct.ProductName, firstReturnedProduct.ProductName);
            Assert.AreEqual(firstProduct.Description, firstReturnedProduct.Description);
            Assert.AreEqual(firstProduct.Price, firstReturnedProduct.Price);
            Assert.AreEqual(firstProduct.Quantity, firstReturnedProduct.Quantity);
            Assert.AreEqual(firstProduct.OriginCountry, firstReturnedProduct.OriginCountry);
            Assert.AreEqual(firstProduct.ProductCode, firstReturnedProduct.ProductCode);

            Assert.AreEqual(secondProduct.ProductName, secondReturnedProduct.ProductName);
            Assert.AreEqual(secondProduct.Description, secondReturnedProduct.Description);
            Assert.AreEqual(secondProduct.Price, secondReturnedProduct.Price);
            Assert.AreEqual(secondProduct.Quantity, secondReturnedProduct.Quantity);
            Assert.AreEqual(secondProduct.OriginCountry, secondReturnedProduct.OriginCountry);
            Assert.AreEqual(secondProduct.ProductCode, secondReturnedProduct.ProductCode);

        }

        [Test]
        public async Task GetAllAsync_WhenNoProductsExist_ShouldThrowKeyNotFoundException()
        {
            // Act
            var exeption = Assert.ThrowsAsync<KeyNotFoundException>(async () => await productsManager.GetAllAsync());

            // Assert
            Assert.That(exeption.Message, Is.EqualTo("No product found."));
        }

        [Test]
        public async Task SearchByOriginCountry_WithExistingOriginCountry_ShouldReturnMatchingProducts()
        {
            // Arrange
            var firstProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(firstProduct);

            var secondProduct = new Product()
            {
                OriginCountry = "Serbia",
                ProductName = "Second TestProduct",
                ProductCode = "AB13C",
                Price = 5.95m,
                Quantity = 9,
                Description = "Some description"
            };

            await productsManager.AddAsync(secondProduct);

            // Act
            var returnedProduct = await productsManager.SearchByOriginCountry(secondProduct.OriginCountry);
            var searchedProduct = returnedProduct.FirstOrDefault();

            // Assert
            Assert.AreEqual(secondProduct.ProductName, searchedProduct.ProductName);
            Assert.AreEqual(secondProduct.Description, searchedProduct.Description);
            Assert.AreEqual(secondProduct.Price, searchedProduct.Price);
            Assert.AreEqual(secondProduct.Quantity, searchedProduct.Quantity);
            Assert.AreEqual(secondProduct.OriginCountry, searchedProduct.OriginCountry);
            Assert.AreEqual(secondProduct.ProductCode, searchedProduct.ProductCode);
        }

        [Test]
        public async Task SearchByOriginCountryAsync_WithNonExistingOriginCountry_ShouldThrowKeyNotFoundException()
        {

            // Act
            var exeption = Assert.ThrowsAsync<KeyNotFoundException>(async () => await productsManager.SearchByOriginCountry("InvalidOriginCountry"));

            // Assert
            Assert.That(exeption.Message, Is.EqualTo("No product found with the given country of origin."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidProductCode_ShouldReturnProduct()
        {
            var firstProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(firstProduct);

            var secondProduct = new Product()
            {
                OriginCountry = "Serbia",
                ProductName = "Second TestProduct",
                ProductCode = "AB13C",
                Price = 5.95m,
                Quantity = 9,
                Description = "Some description"
            };

            await productsManager.AddAsync(secondProduct);

            // Act
            var returnedProduct = await productsManager.GetSpecificAsync(secondProduct.ProductCode);

            // Assert
            Assert.AreEqual(secondProduct.ProductName, returnedProduct.ProductName);
            Assert.AreEqual(secondProduct.Description, returnedProduct.Description);
            Assert.AreEqual(secondProduct.Price, returnedProduct.Price);
            Assert.AreEqual(secondProduct.Quantity, returnedProduct.Quantity);
            Assert.AreEqual(secondProduct.OriginCountry, returnedProduct.OriginCountry);
            Assert.AreEqual(secondProduct.ProductCode, returnedProduct.ProductCode);

        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidProductCode_ShouldThrowKeyNotFoundException()
        {
            // Act
            var exeption = Assert.ThrowsAsync<KeyNotFoundException>(async () => await productsManager.GetSpecificAsync("InvalidProductCode"));

            // Assert
            Assert.That(exeption.Message, Is.EqualTo("No product found with product code: InvalidProductCode"));
        }

        [Test]
        public async Task UpdateAsync_WithValidProduct_ShouldUpdateProduct()
        {
            // Arrange
            var firstProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(firstProduct);

            var secondProduct = new Product()
            {
                OriginCountry = "Serbia",
                ProductName = "Second TestProduct",
                ProductCode = "AB13C",
                Price = 5.95m,
                Quantity = 9,
                Description = "Some description"
            };

            await productsManager.AddAsync(secondProduct);

            var updatedProduct = firstProduct;
            updatedProduct.ProductName = "UPDATED";

            // Act
            await productsManager.UpdateAsync(updatedProduct);
            var firstProductInDb = await this.dbContext.Products.FirstOrDefaultAsync(x => x.ProductCode == firstProduct.ProductCode);
            var secondProductInDb = await this.dbContext.Products.FirstOrDefaultAsync(x => x.ProductCode == secondProduct.ProductCode);

            // Assert
            Assert.AreEqual(firstProduct.ProductName, firstProductInDb.ProductName);
            Assert.AreEqual(firstProduct.Description, firstProductInDb.Description);
            Assert.AreEqual(firstProduct.Price, firstProductInDb.Price);
            Assert.AreEqual(firstProduct.Quantity, firstProductInDb.Quantity);
            Assert.AreEqual(firstProduct.OriginCountry, firstProductInDb.OriginCountry);
            Assert.AreEqual(firstProduct.ProductCode, firstProductInDb.ProductCode);

            Assert.AreEqual(secondProduct.ProductName, secondProductInDb.ProductName);
            Assert.AreEqual(secondProduct.Description, secondProductInDb.Description);
            Assert.AreEqual(secondProduct.Price, secondProductInDb.Price);
            Assert.AreEqual(secondProduct.Quantity, secondProductInDb.Quantity);
            Assert.AreEqual(secondProduct.OriginCountry, secondProductInDb.OriginCountry);
            Assert.AreEqual(secondProduct.ProductCode, secondProductInDb.ProductCode);
        }

            [Test]
            public async Task UpdateAsync_WithInvalidProduct_ShouldThrowValidationException()
            {
            // Act
            var exeptioin = Assert.ThrowsAsync<ValidationException>(async () => await productsManager.UpdateAsync(new Product()));

            // Assert
            Assert.That(exeptioin.Message, Is.EqualTo("Invalid product!"));
            }
        }
    }

