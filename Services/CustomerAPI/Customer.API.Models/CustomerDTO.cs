using Customer.API.Models.DbOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.API.Models
{
    public class CustomerDTO: CreatedUpdated
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string?  Name{ get; set; }
        public string? Email { get; set; }
        public Address Address { get; set; }
        public Guid AddressId { get; set; }
    }
}
