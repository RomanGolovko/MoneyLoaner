namespace Models.Business
{
    public class Borrower : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Voucher { get; set; }
    }
}
