using System.Text;
using CustomerService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly FirebaseService _firebaseService;
        private readonly HttpClient _httpClient;


        public CustomerController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {          

            var response = await _httpClient.GetAsync($"https://customertask-fd2e5-default-rtdb.europe-west1.firebasedatabase.app/Customers.json");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<Customer>>(jsonResponse);

            return Ok(data);
        }

        [HttpGet("{customerID}")]
        public async Task<IActionResult> GetCustomer(int customerID)
        {
            var response = await _httpClient.GetStringAsync($"https://customertask-fd2e5-default-rtdb.europe-west1.firebasedatabase.app/Customers/{customerID}.json");
            var data = JsonConvert.DeserializeObject<Customer>(response);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            customer.CreatedUser = "Admin";
            customer.CreatedDttm = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(customer);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");          
            var response = await _httpClient.PutAsync($"https://customertask-fd2e5-default-rtdb.europe-west1.firebasedatabase.app/Customers/{customer.CustomerID}.json", content);            
            return Ok(response.EnsureSuccessStatusCode());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            customer.UpdatedUser = "Admin";
            customer.UpdatedDttm = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(customer);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");          
            var response = await _httpClient.PutAsync($"https://customertask-fd2e5-default-rtdb.europe-west1.firebasedatabase.app/Customers/{customer.CustomerID}.json", content);            
            return Ok(response.EnsureSuccessStatusCode());
        }

        [HttpDelete("{customerID}")]
        public async Task<IActionResult> DeleteCustomer(int customerID)
        {
            var response = await _httpClient.DeleteAsync($"https://customertask-fd2e5-default-rtdb.europe-west1.firebasedatabase.app/Customers/{customerID}.json");
            return Ok(response.EnsureSuccessStatusCode());
        }
    }
}
