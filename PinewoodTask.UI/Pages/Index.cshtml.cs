using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PinewoodTask.UI.Data;
using PinewoodTask.UI.Model;

namespace PinewoodTask.UI.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly ICustomerData _customerData; 
    
    [BindProperty]
    public Customer customer { get; set; }
    public List<Customer> customerList { get; set; }

    public string SubmitButtonText { get; set; } = "Add";

    public IndexModel(ICustomerData customerData, ILogger<IndexModel> logger)
    {
        _logger = logger;
        _customerData = customerData; 
    }

    public async Task OnGetAsync(int? id)
    {
        if (id.HasValue)
        {
            customer = await _customerData.GetCustomer(id.Value);
            if (customer != null)
            {
                SubmitButtonText = "Update";
            }
        }

        customerList = await _customerData.GetAllCustomers();      
        if(customerList != null)    
            customerList.RemoveAll(item => item == null);           
    }

    public async Task<IActionResult> OnPostAsync()
    {      
         if(customer.CustomerID == 0) 
            return RedirectToPage();
       
        bool response = await _customerData.AddCustomer(customer);  

        return RedirectToPage();
    }


    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        bool response = await _customerData.DeleteCustomer(id);
        if(response) 
            return RedirectToPage();
        else 
            return NotFound(); 
    }
}
