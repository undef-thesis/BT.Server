namespace BT.Application.DTO
{
    public class AddressDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Range { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}