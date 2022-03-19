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
    public class CreateCustomerCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyUsedEmailIsGıven_InvalidOperationException_ShouldBeReturn()
        {
            var customer = new CustomerDTO
            {
                Name = "Testname",
                Email = "WhenAlreadyUsedEmailIsGıven_InvalidOperationException_ShouldBeReturn",
                Address = new Address
                {
                    Id = new Guid("4f432bd5-0a30-440f-ab62-4fa3daa77723"),
                    City = "TestCity",
                    Country = "Turkey",
                    CityCode = 1
                }
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.CreateModel = new CustomerCreateModel()
            {
                Name = customer.Name,
                Address = customer.Address,
                Email = customer.Email
            };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Email is already in use");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Customer_ShouldBeCreated()
        {
            CreateCustomerCommand _command = new CreateCustomerCommand(_context, _mapper);
            CustomerCreateModel model = new CustomerCreateModel() 
            { Name="TestName",Email="test@mail.com",Address = new Address { Id = new Guid("0a632d27-3dd0-4ce1-9527-478b8f4e714c"), 
                City ="Istanbul",CityCode = 34,Country="Turkey"} };
            _command.CreateModel = model;

            //act
            FluentActions.Invoking(() => _command.Handle()).Invoke();   

            //assert
            var customer = _context.Customers.SingleOrDefault(c=>c.Email == model.Email);
            customer.Should().NotBeNull();  
            customer.Name.Should().Be(model.Name);
            customer.Address.Should().Be(model.Address);
            
        }
    } 
}
