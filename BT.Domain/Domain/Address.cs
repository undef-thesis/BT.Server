using System;

namespace BT.Domain.Domain
{
    public class Address
    {
        public Guid Id { get; private set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public Guid MeetingId { get; private set; }
        public Meeting Meeting { get; private set; }

        protected Address() {}

        public Address(double latitude, double longitude, string country, string province, string city, string street, Guid meetingId)
        {
            Id = Guid.NewGuid();
            Latitude = latitude;
            Longitude = longitude;
            Country = country;
            Province = province;
            City = city;
            Street = street;
            MeetingId = meetingId;
        }

    }
}