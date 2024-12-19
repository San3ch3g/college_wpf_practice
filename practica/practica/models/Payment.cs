using System;

public class Payment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string UserName { get; set; } 
    public string ProductName { get; set; }
}