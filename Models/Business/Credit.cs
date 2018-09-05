using System;

namespace Models.Business
{
    public class Credit : BaseModel
    {
        public Borrower Borrower { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public DateTime? Since { get; set; }
        public DateTime? Till { get; set; }
        public decimal? Percentage { get; set; }
    }
}
