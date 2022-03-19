using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.API.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }    
        public string Country { get; set; }  
        public int CityCode { get; set; }
        public string AddressLine => $"{City} {Country} {CityCode}";
    }
}
