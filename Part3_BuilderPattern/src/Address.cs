namespace Part3_BuilderPattern.src;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    

    public Address(string street, string city, string country, string? state, string? zipCode)
    {
        Street = street;
        City = city;
        Country = country;
        State = state;
        ZipCode = ZipCode;
    }
}

