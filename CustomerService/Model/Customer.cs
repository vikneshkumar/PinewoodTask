using System;
using Google.Cloud.Firestore;

namespace CustomerService.Model;

public class Customer
{    
    public int CustomerID { get; set; }
    public string? CustomerName { get; set; }
    public string? Location { get; set; }    
    public string? CreatedUser { get; set; }
    public DateTime CreatedDttm { get; set; }
    public string? UpdatedUser { get; set; }
    public DateTime UpdatedDttm { get; set; }
}
