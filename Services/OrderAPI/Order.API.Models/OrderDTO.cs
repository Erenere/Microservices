using Customer.API.Models;
using Customer.API.Models.DbOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.API.Models
{
    public class OrderDTO : CreatedUpdated
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }

        public string Status { get; set; }

        public Guid AddressId { get; set; }
        [JsonConverter(typeof(OrderConverter))]
        public Address Address { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
