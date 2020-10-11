using System;

namespace BT.Domain.Domain
{
    public class City
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string CountryCode { get; private set; }
    }
}