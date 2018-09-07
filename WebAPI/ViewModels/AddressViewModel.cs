namespace WebAPI.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Apartments { get; set; }
    }
}