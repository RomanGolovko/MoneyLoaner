using System.ComponentModel.DataAnnotations;

namespace Models.BusinessModels
{
    public class BorrowerEntity : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [StringLength(13)]
        public string PhoneNumber { get; set; }

        public byte[] Photo { get; set; }

        public byte[] Voucher { get; set; }

        // navigation properties
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}