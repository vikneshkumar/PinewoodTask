using PinewoodTask.UI.Model;
using Newtonsoft.Json;
using System.Text;

namespace PinewoodTask.UI.Data;

public interface ICustomerData
{
    Task<List<Customer>> GetAllCustomers();

    Task<Customer> GetCustomer(int customerID);

    Task<bool> AddCustomer(Customer customer);

    Task<bool> UpdateCustomer(Customer customer);

    Task<bool> DeleteCustomer(int customerID);
}


public class CustomerData : ICustomerData
{
    private readonly HttpClient _httpClient;
    private string CustomerApiUrl = "http://localhost:5153/api/Customer/"; 

    public CustomerData()
    {
        _httpClient = new HttpClient();
    }


    /// <summary>
    /// Call an API to get all the customer
    /// </summary>
    /// <returns>Customers List</returns>
    public async Task<List<Customer>> GetAllCustomers()
    {
        var result = new List<Customer>();
        string requestUrl = CustomerApiUrl + "GetAllCustomers";
        var response = await _httpClient.GetAsync(requestUrl);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        result = JsonConvert.DeserializeObject<List<Customer>>(jsonResponse);

        return result;
    }

    /// <summary>
    /// Call an API to customer details by ID
    /// </summary>
    /// <returns>Customer details</returns>
    public async Task<Customer> GetCustomer(int customerID)
    {
        var result = new Customer();
        var response = await _httpClient.GetAsync(CustomerApiUrl + $"{customerID}");
        var jsonResponse = await response.Content.ReadAsStringAsync();
        result = JsonConvert.DeserializeObject<Customer>(jsonResponse);
        return result;
    }

    /// <summary>
    /// Call an API to add new customer 
    /// </summary>
    /// <returns>Boolean</returns>
    public async Task<bool> AddCustomer(Customer customer)
    {        
        var jsonData = JsonConvert.SerializeObject(customer);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");          
        var response = await _httpClient.PostAsync(CustomerApiUrl, content); 
        return true;
    }

    /// <summary>
    ///  Call an API to update existing customer 
    /// </summary>
    /// <returns>Boolean</returns>
    public async Task<bool> UpdateCustomer(Customer customer)
    {
        var jsonData = JsonConvert.SerializeObject(customer);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");          
        var response = await _httpClient.PutAsync(CustomerApiUrl, content);            
        return true;
    }

    /// <summary>
    /// Call an API to delete customer 
    /// </summary>
    /// <returns>Boolean</returns>
    public async Task<bool> DeleteCustomer(int customerID)
    {
        var response = await _httpClient.DeleteAsync(CustomerApiUrl + $"{customerID}");
        return true;
    }
}
