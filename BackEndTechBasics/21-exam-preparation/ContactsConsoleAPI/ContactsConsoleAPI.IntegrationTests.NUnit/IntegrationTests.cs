using ContactsConsoleAPI.Business;
using ContactsConsoleAPI.Business.Contracts;
using ContactsConsoleAPI.Data.Models;
using ContactsConsoleAPI.DataAccess;
using ContactsConsoleAPI.DataAccess.Contrackts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestContactDbContext dbContext;
        private IContactManager contactManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestContactDbContext();
            this.contactManager = new ContactManager(new ContactRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddContactAsync_ShouldAddNewContact()
        {
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            var dbContact = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            Assert.NotNull(dbContact);
            Assert.AreEqual(newContact.FirstName, dbContact.FirstName);
            Assert.AreEqual(newContact.LastName, dbContact.LastName);
            Assert.AreEqual(newContact.Phone, dbContact.Phone);
            Assert.AreEqual(newContact.Email, dbContact.Email);
            Assert.AreEqual(newContact.Address, dbContact.Address);
            Assert.AreEqual(newContact.Contact_ULID, dbContact.Contact_ULID);
        }

        //Negative test
        [Test]
        public async Task AddContactAsync_TryToAddContactWithInvalidCredentials_ShouldThrowException()
        {
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "invalid_Mail", //invalid email
                Gender = "Male",
                Phone = "0889933779"
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await contactManager.AddAsync(newContact));
            var actual = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            Assert.IsNull(actual);
            Assert.That(ex?.Message, Is.EqualTo("Invalid contact!"));

        }

        [Test]
        public async Task DeleteContactAsync_WithValidULID_ShouldRemoveContactFromDb()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            // Act
            await contactManager.DeleteAsync(newContact.Contact_ULID);
            var actual = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            // Assert
            Assert.IsNull(actual);
        }

        [TestCase ("   ")]
        [TestCase (null)]
        public async Task DeleteContactAsync_TryToDeleteWithNullOrWhiteSpaceULID_ShouldThrowException(string invalidULID)
        {
            // Act
            var exeption = Assert.ThrowsAsync<ArgumentException>(async () => await contactManager.DeleteAsync(invalidULID));

            // Assert
            Assert.That(exeption.Message, Is.EqualTo("ULID cannot be empty."));           
        }

        [Test]
        public async Task GetAllAsync_WhenContactsExist_ShouldReturnAllContacts()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            var secondNewContact = new Contact()
            {
                FirstName = "SecondTestFirstName",
                LastName = "SecondTestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "2ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "second_test@gmail.com",
                Gender = "Female",
                Phone = "0889933777"
            };

            await contactManager.AddAsync(secondNewContact);

            // Act
            var allContacts = await contactManager.GetAllAsync();

            // Assert
            Assert.That(allContacts.Count, Is.EqualTo(2));

            var firstContactInDb = allContacts.FirstOrDefault();
            var secondContactInDb = allContacts.Skip(1).FirstOrDefault();

            Assert.AreEqual(newContact.FirstName, firstContactInDb.FirstName);
            Assert.AreEqual(newContact.LastName, firstContactInDb.LastName);
            Assert.AreEqual(newContact.Phone, firstContactInDb.Phone);
            Assert.AreEqual(newContact.Email, firstContactInDb.Email);
            Assert.AreEqual(newContact.Address, firstContactInDb.Address);
            Assert.AreEqual(newContact.Contact_ULID, firstContactInDb.Contact_ULID);

            Assert.AreEqual(secondNewContact.FirstName, secondContactInDb.FirstName);
            Assert.AreEqual(secondNewContact.LastName, secondContactInDb.LastName);
            Assert.AreEqual(secondNewContact.Phone, secondContactInDb.Phone);
            Assert.AreEqual(secondNewContact.Email, secondContactInDb.Email);
            Assert.AreEqual(secondNewContact.Address, secondContactInDb.Address);
            Assert.AreEqual(secondNewContact.Contact_ULID, secondContactInDb.Contact_ULID);
        }

        [Test]
        public async Task GetAllAsync_WhenNoContactsExist_ShouldThrowKeyNotFoundException()
        {
            // Act
            var exeption = Assert.ThrowsAsync<KeyNotFoundException>(async() => await contactManager.GetAllAsync());

            // Assert

            Assert.That(exeption.Message, Is.EqualTo("No contact found."));
        }

        [Test]
        public async Task SearchByFirstNameAsync_WithExistingFirstName_ShouldReturnMatchingContacts()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            var secondNewContact = new Contact()
            {
                FirstName = "SecondTestFirstName",
                LastName = "SecondTestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "2ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "second_test@gmail.com",
                Gender = "Female",
                Phone = "0889933777"
            };
            await contactManager.AddAsync(secondNewContact);

            // Act
            var searchingContacts = await contactManager.SearchByFirstNameAsync(newContact.FirstName);
            var firstContactInSearch = searchingContacts.FirstOrDefault();
            // Assert
            Assert.AreEqual(newContact.FirstName, firstContactInSearch.FirstName);
            Assert.AreEqual(newContact.LastName, firstContactInSearch.LastName);
            Assert.AreEqual(newContact.Phone, firstContactInSearch.Phone);
            Assert.AreEqual(newContact.Email, firstContactInSearch.Email);
            Assert.AreEqual(newContact.Address, firstContactInSearch.Address);
            Assert.AreEqual(newContact.Contact_ULID, firstContactInSearch.Contact_ULID);
        }

        [Test]
        public async Task SearchByFirstNameAsync_WithNonExistingFirstName_ShouldThrowKeyNotFoundException()
        {
            // Act
            var exeptioin = Assert.ThrowsAsync<KeyNotFoundException>(async () => await contactManager.SearchByFirstNameAsync("Non existing Name"));

            // Assert
            Assert.That(exeptioin.Message, Is.EqualTo("No contact found with the given first name."));
        }

        [Test]
        public async Task SearchByLastNameAsync_WithExistingLastName_ShouldReturnMatchingContacts()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            var secondNewContact = new Contact()
            {
                FirstName = "SecondTestFirstName",
                LastName = "SecondTestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "2ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "second_test@gmail.com",
                Gender = "Female",
                Phone = "0889933777"
            };
            await contactManager.AddAsync(secondNewContact);

            // Act
            var searchingContacts = await contactManager.SearchByLastNameAsync(newContact.LastName);
            var firstContactInSearch = searchingContacts.FirstOrDefault();
            // Assert
            Assert.AreEqual(newContact.FirstName, firstContactInSearch.FirstName);
            Assert.AreEqual(newContact.LastName, firstContactInSearch.LastName);
            Assert.AreEqual(newContact.Phone, firstContactInSearch.Phone);
            Assert.AreEqual(newContact.Email, firstContactInSearch.Email);
            Assert.AreEqual(newContact.Address, firstContactInSearch.Address);
            Assert.AreEqual(newContact.Contact_ULID, firstContactInSearch.Contact_ULID);
        }

        [Test]
        public async Task SearchByLastNameAsync_WithNonExistingLastName_ShouldThrowKeyNotFoundException()
        {
            // Act
            var exeptioin = Assert.ThrowsAsync<KeyNotFoundException>(async () => await contactManager.SearchByLastNameAsync("Non existing Name"));

            // Assert
            Assert.That(exeptioin.Message, Is.EqualTo("No contact found with the given last name."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidULID_ShouldReturnContact()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            var secondNewContact = new Contact()
            {
                FirstName = "SecondTestFirstName",
                LastName = "SecondTestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "2ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "second_test@gmail.com",
                Gender = "Female",
                Phone = "0889933777"
            };
            await contactManager.AddAsync(secondNewContact);

            // Act
            var searchingContacts = await contactManager.GetSpecificAsync(newContact.Contact_ULID);
            
            // Assert
            Assert.AreEqual(newContact.FirstName, searchingContacts.FirstName);
            Assert.AreEqual(newContact.LastName, searchingContacts.LastName);
            Assert.AreEqual(newContact.Phone, searchingContacts.Phone);
            Assert.AreEqual(newContact.Email, searchingContacts.Email);
            Assert.AreEqual(newContact.Address, searchingContacts.Address);
            Assert.AreEqual(newContact.Contact_ULID, searchingContacts.Contact_ULID);
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidULID_ShouldThrowKeyNotFoundException()
        {
            //Arrange
            var invalidULID = "1Ase@";
            // Act
            var exeption = Assert.ThrowsAsync<KeyNotFoundException>(async () => await contactManager.GetSpecificAsync(invalidULID));

            // Assert
            Assert.That(exeption.Message, Is.EqualTo($"No contact found with ULID: {invalidULID}"));
        }

        [Test]
        public async Task UpdateAsync_WithValidContact_ShouldUpdateContact()
        {
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            var secondNewContact = new Contact()
            {
                FirstName = "SecondTestFirstName",
                LastName = "SecondTestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "2ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "second_test@gmail.com",
                Gender = "Female",
                Phone = "0889933777"
            };
            await contactManager.AddAsync(secondNewContact);

            var updatedContact = newContact;
            updatedContact.LastName = "UPDATED";

            //Act
            await contactManager.UpdateAsync(updatedContact);
            var contactInDb = await contactManager.GetSpecificAsync(updatedContact.Contact_ULID);

            // Assert
            Assert.AreEqual(updatedContact.FirstName, contactInDb.FirstName);
            Assert.AreEqual(updatedContact.LastName, contactInDb.LastName);
            Assert.AreEqual(updatedContact.Phone, contactInDb.Phone);
            Assert.AreEqual(updatedContact.Email, contactInDb.Email);
            Assert.AreEqual(updatedContact.Address, contactInDb.Address);
            Assert.AreEqual(updatedContact.Contact_ULID, contactInDb.Contact_ULID);
        }

        [Test]
        public async Task UpdateAsync_WithInvalidContact_ShouldThrowValidationException()
        {
            // Act & Assert
            var exeption = Assert.ThrowsAsync<ValidationException>(async () => await contactManager.UpdateAsync(new Contact()));
            Assert.That(exeption.Message, Is.EqualTo("Invalid contact!"));
        }
    }
}
