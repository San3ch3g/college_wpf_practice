using System.Collections.Generic;

namespace pracrica.models
{
    public class ReportCategory
    {
        public string CategoryName { get; set; }
        public List<ReportProduct> Products { get; set; } = new List<ReportProduct>();
        public decimal TotalAmount { get; set; }
    }
}