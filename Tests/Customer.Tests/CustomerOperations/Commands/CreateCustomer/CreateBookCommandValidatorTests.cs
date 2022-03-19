using AutoMapper;
using Customer.API.CustomerOperations.Commands.CreateCustomer;
using Customer.API.Models;
using Customer.API.Models.DbOperations;
using Customer.Tests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Customer.Tests.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [ClassData(typeof(CustomerClassData))]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(CustomerCreateModel customer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.CreateModel = customer;

            CreateCustomerModelValidator validator = new CreateCustomerModelValidator();
            var resultErrors = validator.Validate(command);

            resultErrors.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.CreateModel = new CustomerCreateModel()
            {
                Name = "Test name",
                Address = new Address()
                {
                    City = "test city",
                    CityCode = 10,
                    Country = "Turkey",
                    Id = new Guid("23247feb-8b36-41bd-82d7-cda6a76e1dae")
                },
                Email = "testmailll@mail.com"
            };

            CreateCustomerModelValidator validator = new CreateCustomerModelValidator();
            var resultErrors = validator.Validate(command);

            resultErrors.Errors.Count.Should().Be(0);
        }
    }
}
