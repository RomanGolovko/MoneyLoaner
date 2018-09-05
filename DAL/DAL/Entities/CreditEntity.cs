using System;
using System.ComponentModel.DataAnnotations;

namespace Models.BusinessModels
{
    public class CreditEntity : BaseEntity
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public DateTime Since { get; set; }

        public DateTime Till { get; set; }

        public decimal Percentage { get; set; }

        // navigation properties
        public int BorrowerId { get; set; }
        public virtual BorrowerEntity Borrower { get; set; }
    }
}
