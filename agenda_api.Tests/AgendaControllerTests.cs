using agenda_api.Controllers;
using agenda_api.Services;
using agenda_api.Repositories;
using Moq;
using agenda_api.Models;

namespace agenda_api.Tests;

public class AgendaControllerTests
{
    public int Id { get; private set; }

    [Fact]
    public void GetContacts_ReturnContactList()
    {
        // Arrange
        var mockRepository = new Mock<ContactRepository>();
        var mockService = new Mock<IContactService>();

        var mockContact = new List<Contact>
        {
            new Contact { Id = 1, Name = "teste", Phone = "9999-9999", Email = "teste@gmail.com" },
            new Contact { Id = 2, Name = "test2", Phone = "8888-8888", Email = "teste2@gmail.com" }
        };
        
        mockRepository.Setup(repo => repo.FindAll(0,10)).Returns(mockContact);
        mockService.Setup(service => service.FindAllContacts(0,10)).Returns(mockContact);


        var controller = new AgendaController(mockService.Object);

        // Act
        var result = controller.GetContacts();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetContactById_ReturnContact()
    {
        // Arrange
        var contactId = 1;
        var mockRepository = new Mock<ContactRepository>();
        var mockService = new Mock<IContactService>();

        var mockContact = new Contact { Id = 1, Name = "test", Phone = "8888-8888", Email = "teste@gmail.com" };
        
        mockRepository.Setup(repo => repo.FindById(contactId)).Returns(mockContact);
        mockService.Setup(service => service.FindContactById(contactId)).Returns(mockContact);


        var controller = new AgendaController(mockService.Object);

        // Act
        var result = controller.GetContactById(contactId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void AddContact_SuccessfullyCreatedContact()
    {
        // Arrange
        var mockRepository = new Mock<ContactRepository>();
        var mockService = new Mock<IContactService>();
        var mockContact = new Contact { Id = 1, Name = "test", Phone = "8888-8888", Email = "teste@gmail.com" };
        
        mockRepository.Setup(repo => repo.Insert(mockContact));
        mockService.Setup(service => service.InsertContact(mockContact)).Returns(true);
        var controller = new AgendaController(mockService.Object);

        // Act
        var result = controller.AddContact(mockContact);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateContact_SuccessfullyUpdatedContact()
    {
        // Arrange
        var mockRepository = new Mock<ContactRepository>();
        var mockService = new Mock<IContactService>();
        var mockContact = new Contact { Id = 1, Name = "test", Phone = "8888-8888", Email = "teste@gmail.com" };
        
        mockRepository.Setup(repo => repo.Update(mockContact));
        mockService.Setup(service => service.UpdateContact(mockContact.Id, mockContact)).Returns(true);
        var controller = new AgendaController(mockService.Object);

        // Act
        var result = controller.UpdateContact(mockContact.Id, mockContact);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateContact_ContactToUpdateWasNotFound()
    {
        // Arrange
        var mockRepository = new Mock<ContactRepository>();
        var mockService = new Mock<IContactService>();
        var mockContact = new Contact { Id = 1, Name = "test", Phone = "8888-8888", Email = "teste@gmail.com" };
        
        mockRepository.Setup(repo => repo.Update(mockContact));
        mockService.Setup(service => service.UpdateContact(mockContact.Id, mockContact)).Returns(false);
        var controller = new AgendaController(mockService.Object);

        // Act
        var result = controller.UpdateContact(mockContact.Id, mockContact);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void DeleteContact_SuccessfullyDeletedContact()
    {
        // Arrange
        var mockRepository = new Mock<ContactRepository>();
        var mockService = new Mock<IContactService>();
        var mockContact = new Contact { Id = 1, Name = "test", Phone = "8888-8888", Email = "teste@gmail.com" };
        
        mockRepository.Setup(repo => repo.Delete(mockContact));
        mockService.Setup(service => service.DeleteContact(mockContact.Id)).Returns(true);
        var controller = new AgendaController(mockService.Object);

        // Act
        var result = controller.DeleteContact(mockContact.Id);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteContact_ContactToDeleteWasNotFound()
    {
        // Arrange
        var mockRepository = new Mock<ContactRepository>();
        var mockService = new Mock<IContactService>();
        var mockContact = new Contact { Id = 1, Name = "test", Phone = "8888-8888", Email = "teste@gmail.com" };
        
        mockRepository.Setup(repo => repo.Update(mockContact));
        mockService.Setup(service => service.DeleteContact(mockContact.Id)).Returns(false);
        var controller = new AgendaController(mockService.Object);

        // Act
        var result = controller.DeleteContact(mockContact.Id);

        // Assert
        Assert.False(result);
    }
}