using System;

namespace BT.Domain.Domain
{
    public class Address
    {
        public Guid Id { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public int Range { get; private set; }
        public string Country { get; private set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string PostalCode { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Guid MeetingId { get; private set; }
        public Meeting Meeting { get; private set; }

        protected Address() { }

        public Address(double latitude, double longitude, int range, string country, string province,
            string postalCode, string city, string street, Guid meetingId)
        {
            Id = Guid.NewGuid();
            Latitude = latitude;
            Longitude = longitude;
            Range = range;
            Country = country;
            Province = province;
            City = city;
            Street = street;
            PostalCode = postalCode;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

            MeetingId = meetingId;
        }

        public void UpdateAddress(double latitude, double longitude, int range, string country, string province,
            string postalCode, string city, string street)
        {
            Latitude = latitude;
            Longitude = longitude;
            Range = range;
            Country = country;
            Province = province;
            City = city;
            Street = street;
            PostalCode = postalCode;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}