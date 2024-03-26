using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;
using ZooConsoleAPI.Business;
using ZooConsoleAPI.Business.Contracts;
using ZooConsoleAPI.Data.Model;
using ZooConsoleAPI.DataAccess;

namespace ZooConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestAnimalDbContext dbContext;
        private IAnimalsManager animalsManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestAnimalDbContext();
            this.animalsManager = new AnimalsManager(new AnimalRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddAnimalAsync_ShouldAddNewAnimal()
        {
            // Arrange
            var dog = new Animal()
            {
                CatalogNumber = "123456789AYZ",
                Name = "Bary",
                Breed = "San Bernar",
                Type = "mammal",
                Age = 2,
                Gender = "Male",
                IsHealthy = true
            };

            // Act
            await this.animalsManager.AddAsync(dog);
            var animalInDb = await this.dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == dog.CatalogNumber);

            // Assert
            Assert.That(animalInDb, Is.Not.Null);
            Assert.That(animalInDb.CatalogNumber, Is.EqualTo(dog.CatalogNumber));
            Assert.That(animalInDb.Name, Is.EqualTo(dog.Name));
            Assert.That(animalInDb.Breed, Is.EqualTo(dog.Breed));
            Assert.That(animalInDb.Type, Is.EqualTo(dog.Type));
            Assert.That(animalInDb.Age, Is.EqualTo(dog.Age));
            Assert.That(animalInDb.Gender, Is.EqualTo(dog.Gender));
            Assert.That(animalInDb.IsHealthy, Is.EqualTo(dog.IsHealthy));
        }

        //Negative test
        [Test]
        public async Task AddAnimalAsync_TryToAddAnimalWithInvalidCredentials_ShouldThrowException()
        {
            // Arrange
            var dog = new Animal()
            {
                CatalogNumber = "123456789AYZR",
                Name = "Bary",
                Breed = "San Bernar",
                Type = "mammal",
                Age = 2,
                Gender = "Male",
                IsHealthy = true
            };

            // Act
            var exeption = Assert.ThrowsAsync<ValidationException>(async () => await this.animalsManager.AddAsync(dog));
            var animalInDb = await this.dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == dog.CatalogNumber);

            // Assert
            Assert.That(animalInDb, Is.Null);
            Assert.That(exeption.Message, Is.EqualTo("Invalid animal!"));

        }

        [Test]
        public async Task DeleteAnimalAsync_WithValidCatalogNumber_ShouldRemoveAnimalFromDb()
        {
            // Arrange
            var dog = new Animal()
            {
                CatalogNumber = "123456789AYZ",
                Name = "Bary",
                Breed = "San Bernar",
                Type = "mammal",
                Age = 2,
                Gender = "Male",
                IsHealthy = true
            };

            await this.animalsManager.AddAsync(dog);

            // Act
            await this.animalsManager.DeleteAsync(dog.CatalogNumber);
            var animalInDb = await this.dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == dog.CatalogNumber);

            // Assert
            Assert.That(animalInDb, Is.Null);
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task DeleteAnimalAsync_TryToDeleteWithNullOrWhiteSpaceCatalogNumber_ShouldThrowException(string invalidCatalogNumber)
        {
            // Act & Assert
            var exeption = Assert.ThrowsAsync<ArgumentException>(async () => await this.animalsManager.DeleteAsync(invalidCatalogNumber));
            Assert.That(exeption.Message, Is.EqualTo("Catalog number cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenAnimalsExist_ShouldReturnAllAnimals()
        {
            // Arrange
            var dog = new Animal()
            {
                CatalogNumber = "123456789AYZ",
                Name = "Bary",
                Breed = "San Bernar",
                Type = "mammal",
                Age = 2,
                Gender = "Male",
                IsHealthy = true
            };

            await this.animalsManager.AddAsync(dog);

            var cat = new Animal()
            {
                CatalogNumber = "123456789AYA",
                Name = "Murry",
                Breed = "Seberian",
                Type = "mammal",
                Age = 5,
                Gender = "Female",
                IsHealthy = true
            };

            await this.animalsManager.AddAsync(cat);

            // Act
            var getAllAnimals = await this.animalsManager.GetAllAsync();
            var firstAnimal = getAllAnimals.FirstOrDefault();
            var secondAnimal = getAllAnimals.LastOrDefault();

            // Assert
            Assert.That(getAllAnimals, Is.Not.Null);
            Assert.That(getAllAnimals.Count, Is.EqualTo(2));

            Assert.That(firstAnimal.CatalogNumber, Is.EqualTo(dog.CatalogNumber));
            Assert.That(firstAnimal.Name, Is.EqualTo(dog.Name));
            Assert.That(firstAnimal.Breed, Is.EqualTo(dog.Breed));
            Assert.That(firstAnimal.Type, Is.EqualTo(dog.Type));
            Assert.That(firstAnimal.Age, Is.EqualTo(dog.Age));
            Assert.That(firstAnimal.Gender, Is.EqualTo(dog.Gender));
            Assert.That(firstAnimal.IsHealthy, Is.EqualTo(dog.IsHealthy));

            Assert.That(secondAnimal.CatalogNumber, Is.EqualTo(cat.CatalogNumber));
            Assert.That(secondAnimal.Name, Is.EqualTo(cat.Name));
            Assert.That(secondAnimal.Breed, Is.EqualTo(cat.Breed));
            Assert.That(secondAnimal.Type, Is.EqualTo(cat.Type));
            Assert.That(secondAnimal.Age, Is.EqualTo(cat.Age));
            Assert.That(secondAnimal.Gender, Is.EqualTo(cat.Gender));
            Assert.That(secondAnimal.IsHealthy, Is.EqualTo(cat.IsHealthy));
        }

        [Test]
        public async Task GetAllAsync_WhenNoAnimalsExist_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            var exeption = Assert.ThrowsAsync<KeyNotFoundException>(async () => await this.animalsManager.GetAllAsync());
            Assert.That(exeption, Is.Not.Null);
            Assert.That(exeption.Message, Is.EqualTo("No animal found."));
        }

        [Test]
        public async Task SearchByTypeAsync_WithExistingType_ShouldReturnMatchingAnimals()
        {
            // Arrange
            var dog = new Animal()
            {
                CatalogNumber = "123456789AYZ",
                Name = "Bary",
                Breed = "San Bernar",
                Type = "mammal",
                Age = 2,
                Gender = "Male",
                IsHealthy = true
            };

            await this.animalsManager.AddAsync(dog);

            var cat = new Animal()
            {
                CatalogNumber = "123456789AYA",
                Name = "Murry",
                Breed = "Seberian",
                Type = "mammal",
                Age = 5,
                Gender = "Female",
                IsHealthy = true
            };

            await this.animalsManager.AddAsync(cat);

            var lizard = new Animal()
            {
                CatalogNumber = "123456789AYS",
                Name = "Leonard",
                Breed = "Iguana",
                Type = "lizard",
                Age = 1,
                Gender = "Male",
                IsHealthy = true
            };

            await this.animalsManager.AddAsync(lizard);

            var typeForSearh = "mammal";

            // Act
            var resultSearhByType = await this.animalsManager.SearchByTypeAsync(typeForSearh);
            var firstAnimal = resultSearhByType.FirstOrDefault();
            var secondAnimal = resultSearhByType.LastOrDefault();

            // Assert
            Assert.That(resultSearhByType, Is.Not.Null);
            Assert.That(resultSearhByType.Count, Is.EqualTo(2));

            Assert.That(firstAnimal.CatalogNumber, Is.EqualTo(dog.CatalogNumber));
            Assert.That(firstAnimal.Name, Is.EqualTo(dog.Name));
            Assert.That(firstAnimal.Breed, Is.EqualTo(dog.Breed));
            Assert.That(firstAnimal.Type, Is.EqualTo(dog.Type));
            Assert.That(firstAnimal.Age, Is.EqualTo(dog.Age));
            Assert.That(firstAnimal.Gender, Is.EqualTo(dog.Gender));
            Assert.That(firstAnimal.IsHealthy, Is.EqualTo(dog.IsHealthy));

            Assert.That(secondAnimal.CatalogNumber, Is.EqualTo(cat.CatalogNumber));
            Assert.That(secondAnimal.Name, Is.EqualTo(cat.Name));
            Assert.That(secondAnimal.Breed, Is.EqualTo(cat.Breed));
            Assert.That(secondAnimal.Type, Is.EqualTo(cat.Type));
            Assert.That(secondAnimal.Age, Is.EqualTo(cat.Age));
            Assert.That(secondAnimal.Gender, Is.EqualTo(cat.Gender));
            Assert.That(secondAnimal.IsHealthy, Is.EqualTo(cat.IsHealthy));
        }

        [Test]
        public async Task SearchByTypeAsync_WithNonExistingType_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            var exeption = Assert.ThrowsAsync<KeyNotFoundException>(async () => await this.animalsManager.SearchByTypeAsync("Not-Exixsting-Type"));
            Assert.That(exeption, Is.Not.Null);
            Assert.That(exeption.Message, Is.EqualTo("No animal found with the given type."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidCatalogNumber_ShouldReturnAnimal()
        {
            // Arrange
            var dog = new Animal()
            {
                CatalogNumber = "123456789AYZ",
                Name = "Bary",
                Breed = "San Bernar",
                Type = "mammal",
                Age = 2,
                Gender = "Male",
                IsHealthy = true
            };

            await this.animalsManager.AddAsync(dog);

            var cat = new Animal()
            {
                CatalogNumber = "123456789AYA",
                Name = "Murry",
                Breed = "Seberian",
                Type = "mammal",
                Age = 5,
                Gender = "Female",
                IsHealthy = true
            };

            await this.animalsManager.AddAsync(cat);

            // Act
            var resultGetSpecific = await this.animalsManager.GetSpecificAsync(dog.CatalogNumber);

            // Assert
            Assert.That(resultGetSpecific, Is.Not.Null);
            Assert.That(resultGetSpecific.CatalogNumber, Is.EqualTo(dog.CatalogNumber));
            Assert.That(resultGetSpecific.Name, Is.EqualTo(dog.Name));
            Assert.That(resultGetSpecific.Breed, Is.EqualTo(dog.Breed));
            Assert.That(resultGetSpecific.Type, Is.EqualTo(dog.Type));
            Assert.That(resultGetSpecific.Age, Is.EqualTo(dog.Age));
            Assert.That(resultGetSpecific.Gender, Is.EqualTo(dog.Gender));
            Assert.That(resultGetSpecific.IsHealthy, Is.EqualTo(dog.IsHealthy));
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidCatalogNumber_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            var exeption = Assert.ThrowsAsync<KeyNotFoundException>(async () => await this.animalsManager.GetSpecificAsync("Invalid-Catalog-Number"));
            Assert.That(exeption, Is.Not.Null);
            Assert.That(exeption.Message, Is.EqualTo("No animal found with catalog number: Invalid-Catalog-Number"));
        }

        [Test]
        public async Task UpdateAsync_WithValidAnimal_ShouldUpdateAnimal()
        {
            // Arrange
            var dog = new Animal()
            {
                CatalogNumber = "123456789AYZ",
                Name = "Bary",
                Breed = "San Bernar",
                Type = "mammal",
                Age = 2,
                Gender = "Male",
                IsHealthy = true
            };

            await this.animalsManager.AddAsync(dog);

            var cat = new Animal()
            {
                CatalogNumber = "123456789AYA",
                Name = "Murry",
                Breed = "Seberian",
                Type = "mammal",
                Age = 5,
                Gender = "Female",
                IsHealthy = true
            };

            await this.animalsManager.AddAsync(cat);

            dog.Name = dog.Name + "UPDATED";

            // Act
            await this.animalsManager.UpdateAsync(dog);
            var resultGetAll = await this.animalsManager.GetAllAsync();
            var firstAnimal = resultGetAll.FirstOrDefault();
            var secondAnimal = resultGetAll.LastOrDefault();

            // Assert
            Assert.That(firstAnimal.CatalogNumber, Is.EqualTo(dog.CatalogNumber));
            Assert.That(firstAnimal.Name, Is.EqualTo(dog.Name));
            Assert.That(firstAnimal.Breed, Is.EqualTo(dog.Breed));
            Assert.That(firstAnimal.Type, Is.EqualTo(dog.Type));
            Assert.That(firstAnimal.Age, Is.EqualTo(dog.Age));
            Assert.That(firstAnimal.Gender, Is.EqualTo(dog.Gender));
            Assert.That(firstAnimal.IsHealthy, Is.EqualTo(dog.IsHealthy));

            Assert.That(secondAnimal.CatalogNumber, Is.EqualTo(cat.CatalogNumber));
            Assert.That(secondAnimal.Name, Is.EqualTo(cat.Name));
            Assert.That(secondAnimal.Breed, Is.EqualTo(cat.Breed));
            Assert.That(secondAnimal.Type, Is.EqualTo(cat.Type));
            Assert.That(secondAnimal.Age, Is.EqualTo(cat.Age));
            Assert.That(secondAnimal.Gender, Is.EqualTo(cat.Gender));
            Assert.That(secondAnimal.IsHealthy, Is.EqualTo(cat.IsHealthy));
        }

        [Test]
        public async Task UpdateAsync_WithInvalidAnimal_ShouldThrowValidationException()
        {
            // Arrange
            var dog = new Animal()
            {
                CatalogNumber = "123456789AYZR",
                Name = "Bary",
                Breed = "San Bernar",
                Type = "mammal",
                Age = 2,
                Gender = "Male",
                IsHealthy = true
            };

            // Act & Assert
            var exeption = Assert.ThrowsAsync<ValidationException>(async () => await this.animalsManager.UpdateAsync(dog));
            Assert.That(exeption, Is.Not.Null);
            Assert.That(exeption.Message, Is.EqualTo("Invalid animal!"));
           
        }
    }
}

