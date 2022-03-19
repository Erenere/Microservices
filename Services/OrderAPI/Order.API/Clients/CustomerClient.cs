using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static Customer.API.CustomerOperations.Queries.GetCustomers.GetCustomersQuery;

namespace Order.API.Clients
{
    public class CustomerClient
    {
        private readonly HttpClient _httpClient;
        public CustomerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<CustomersViewModel>> GetCustomersAsync()
        {
            var customers = await _httpClient.GetFromJsonAsync<IReadOnlyCollection<CustomersViewModel>>("/api/customer");
            return customers;
        }
    }
}
