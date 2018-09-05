namespace Models.BusinessModels
{
    public class Address : BaseEntity
    {
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Apartments { get; set; }
    }
}
