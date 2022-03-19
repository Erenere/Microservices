using Customer.API.CustomerOperations.Commands.CreateCustomer;
using Customer.API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Tests.TestSetup
{
    public class CustomerClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new CustomerCreateModel
                {
                    Name = "",
                    Email = "testemail",
                    Address = new Address
                    {
                        Id = new Guid("ed2466b1-6019-4eb3-9440-f0a1e9dbd307"),
                        City= "testcity",
                        Country = "testcountry",
                        CityCode = 123
                    }
                }
            };
            yield return new object[]
            {
                new CustomerCreateModel
                {
                    Name = "sss",
                    Email = "",
                    Address = new Address
                    {
                        Id = new Guid("ed2466b1-6019-4eb3-9440-f0a1e9dbd307"),
                        City= "testcity",
                        Country = "testcountry",
                        CityCode = 123
                    }
                }
            };

            yield return new object[]
            {
                new CustomerCreateModel
                {
                    Name = "",
                    Email = "",
                    Address = new Address
                    {
                        Id = new Guid("ed2466b1-6019-4eb3-9440-f0a1e9dbd307"),
                        City= "testcity",
                        Country = "testcountry",
                        CityCode = 123
                    }
                }
            };
            yield return new object[]
            {
                new CustomerCreateModel
                {
                    Name = "testname",
                    Email = "testmail@c",
                    Address = new Address
                    {
                        City = "",
                        Country = "testttt",
                        CityCode = 1
                    }
                }
            };
            yield return new object[]
            {
                new CustomerCreateModel
                {
                    Name = "eren",
                    Email = "mailtest1",
                    Address = new Address
                    {
                        City = "sa",
                        Country = "",
                        CityCode = 1
                    }
                }
            };

            yield return new object[]
            {
                new CustomerCreateModel
                {
                    Name = "eee",
                    Email = "mtest",
                    Address = new Address
                    {
                        City = "ss",
                        Country = "ss",
                        CityCode = 0
                    }
                }
            };

            yield return new object[]
            {
                new CustomerCreateModel
                {
                    Name = "name1",
                    Email = "mail1",
                    Address = new Address
                    {
                        City = "gga",
                        Country = "",
                        CityCode = 0
                    }
                }
            };
            yield return new object[]
            {
                new CustomerCreateModel
                {
                    Name = "name2",
                    Email = "eeaae",
                    Address = new Address
                    {
                        City = "",
                        Country = "ffff",
                        CityCode = 0
                    }
                }
            };

            yield return new object[]
            {
                new CustomerCreateModel
                {
                    Name = "rrrrr",
                    Email = "testestestest",
                    Address = new Address
                    {
                        City = "",
                        Country = "",
                        CityCode = 0
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
