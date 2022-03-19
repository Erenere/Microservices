using Customer.API.CustomerOperations.Commands.DeleteCustomer;
using Customer.API.Models.DbOperations;
using Customer.Tests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Customer.Tests.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerTests: IClassFixture<CommonTestFixture>
    {
        private readonly CustomerDbContext _dbContext;

        public DeleteCustomerTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }

        [Fact]
        public void WhenCustomerIsNull_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            DeleteCustomerCommand command = new DeleteCustomerCommand(_dbContext);
            command.CustomerId = Guid.NewGuid();
            //act&assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer does not exist");
        }
    }
}
