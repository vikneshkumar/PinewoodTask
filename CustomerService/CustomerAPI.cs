// using CustomerService.Model;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
 

// namespace CustomerService
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class CustomerAPI : ControllerBase
//     {
//         private readonly FirebaseService _firebaseService;

//         public CustomerAPI(FirebaseService firebaseService)
//         {
//             _firebaseService = firebaseService;
//         }

//         [HttpGet]
//         public async Task<IActionResult> GetAllCustomers()
//         {
//             var data = await _firebaseService.GetAll<List<Customer>>();
//             return Ok(data);
//         }

//         [HttpGet]
//         public async Task<IActionResult> GetCustomer(int customerID)
//         {
//             var data = await _firebaseService.GetDataAsync<Customer>(customerID);
//             return Ok(data);
//         }

//         [HttpPost]
//         public async Task<IActionResult> AddCustomer(Customer customerID)
//         {
//             return Ok(true);
//         }

//         [HttpPut]
//         public async Task<IActionResult> UpdateCustomer(Customer customerID)
//         {
//             return Ok(true);;
//         }

//         [HttpDelete]
//         public async Task<IActionResult> DeleteCustomer(int customerID)
//         {
//             return Ok(true);;
//         }
//     }
// }
