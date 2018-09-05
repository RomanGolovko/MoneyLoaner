using System;

namespace WebAPI.ViewModels
{
    public class CreditViewModel
    {
        public int? Id { get; set; }
        public BorrowerViewModel Borrower { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public DateTime? Since { get; set; }
        public DateTime? Till { get; set; }
        public decimal? Percentage { get; set; }
    }
}
