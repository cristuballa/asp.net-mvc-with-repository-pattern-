namespace ApplicationCore.Entities
{
    public class Address: BaseEntity
    {
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
}
