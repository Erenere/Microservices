using AutoMapper;
using Customer.API.CustomerOperations.Queries.GetCustomerDetail;
using Customer.API.Models.DbOperations;
using Customer.Tests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Customer.Tests.CustomerOperations.Queries.GetCustomerDetailQuery
{
    public class GetCustomerDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenCustomerIsNull_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var query = new GetCustomersDetailQuery(_context, _mapper);
            query.CustomerId = Guid.NewGuid();

            //act&assert
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer cannot be found");
        }

        //[Fact]

        //public void WhenValidCustomerIdIsGiven_CustomerDetail_ShouldBeReturn()
        //{
        //    //arrange
        //    var query = new GetCustomersDetailQuery(_context, _mapper);
        //    var customerId = new Guid("07668df6-dceb-43b9-b105-44ff05ea1cd0");
        //    query.CustomerId = customerId;

        //    //act
        //    var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);


        //    //assert
        //    Assert.NotNull(customer);   
        //    Assert.IsAssignableFrom<CustomerDTO>(customer);
        //}

    }
}
