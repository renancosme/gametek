using Microsoft.AspNetCore.Mvc;
using Moq;
using MrGreen.Api.Controllers;
using MrGreen.Application.Services.Interfaces;
using MrGreen.Application.ViewModels;
using System;
using Xunit;

namespace MrGreen.Tests.API
{
    public class CustomerControllerTests
    {
        Mock<ICustomerAppService> _mockCustomerAppService;
        CustomerController _customerController;

        public CustomerControllerTests()
        {
            _mockCustomerAppService = new Mock<ICustomerAppService>();
            _customerController = new CustomerController(_mockCustomerAppService.Object);
        }

        [Fact]
        public void Add_CustomerNull_ReturnsBadRequest()
        {
            // Act
            var badRequestResult = _customerController.Post(null);

            // Assert
            Assert.IsType<BadRequestResult>(badRequestResult);
        }

        [Fact]
        public void Add_Customer_ReturnsCreatedResponse()
        {
            // Arrange            
            var customerGuid = Guid.NewGuid();
            var customerViewModel = new CustomerViewModel
            {
                Id = customerGuid,
                FirstName = "Cliente A",
                LastName = "Last name",
                Address = "Avenue A",
                PersonalNumber = "0508851234"
            };
            
            // Act
            var result = _customerController.Post(customerViewModel);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(result);
            var createdResult = result as CreatedAtRouteResult;
            Assert.Equal(customerGuid, createdResult.RouteValues["id"]);            
        }

        [Fact]
        public void Get_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _customerController.Get(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Get_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var customerGuid = Guid.NewGuid();
            var customerViewModel = new CustomerViewModel
            {
                Id = customerGuid,
                FirstName = "Cliente A",
                LastName = "Last name",
                Address = "Avenue A",
                PersonalNumber = "0508851234"
            };

            _mockCustomerAppService.Setup(c => c.GetById(customerGuid)).Returns(customerViewModel);

            // Act
            var okResult = _customerController.Get(customerGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Put_CustomerNull_ReturnsBadRequest()
        {
            // Act
            var badRequestResult = _customerController.Put(null);

            // Assert
            Assert.IsType<BadRequestResult>(badRequestResult);
        }

        [Fact]
        public void Put_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var customerViewModel = new CustomerViewModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Cliente A",
                LastName = "Last name",
                Address = "Avenue A",
                PersonalNumber = "0508851234"
            };

            // Act
            var notFoundResult = _customerController.Put(customerViewModel);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void Put_ExistingCustomer_ReturnsNoContent()
        {
            // Arrange
            Guid customerId = Guid.NewGuid();
            var customerViewModel = new CustomerViewModel
            {
                Id = customerId,
                FirstName = "Cliente A",
                LastName = "Last name",
                Address = "Avenue A",
                PersonalNumber = "0508851234"
            };

            _mockCustomerAppService.Setup(c => c.GetById(customerId)).Returns(customerViewModel);
            customerViewModel.LastName = "Pinto";
            
            // Act
            var noContentResult = _customerController.Put(customerViewModel);

            // Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }

        [Fact]
        public void Delete_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();

            // Act
            var badResponse = _customerController.Delete(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Delete_ExistingGuidPassed_NoContentResult()
        {
            // Arrange
            Guid customerId = Guid.NewGuid();
            var customerViewModel = new CustomerViewModel
            {
                Id = customerId,
                FirstName = "Cliente A",
                LastName = "Last name",
                Address = "Avenue A",
                PersonalNumber = "0508851234"
            };

            _mockCustomerAppService.Setup(c => c.GetById(customerId)).Returns(customerViewModel);

            // Act
            var noContentResult = _customerController.Delete(customerId);

            // Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }
    }
}
