namespace WebAPI.ViewModels
{
    public class BorrowerViewModel
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string PhoneNumber { get; set; }
        public AddressViewModel Address { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Voucher { get; set; }
    }
}