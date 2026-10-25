using System.ComponentModel;

namespace Part3_BuilderPattern.src;

public class AddressBuilder
{
    private readonly string _street;
    private readonly string _city;
    private readonly string _country;
    private string? _state { get; set; }
    private string? _zipCode { get; set; }

    public AddressBuilder(string street, string city, string country)
    {
        _street = street;
        _city = city;
        _country = country;
    }

    public AddressBuilder WithState(string state)
    {
        _state = state;
        return this;
    }

    public AddressBuilder WithZip(string zipCode)
    {
        _zipCode = zipCode;
        return this;
    }


    public Address Build()
    {
        if(string.IsNullOrEmpty(_street))
            throw new InvalidOperationException($"Street is required.");

        if(string.IsNullOrEmpty(_city))
            throw new InvalidOperationException($"City is required.");

        if(string.IsNullOrEmpty(_country))
            throw new InvalidOperationException($"Country is required.");

        return new Address(_street, _city, _country, _state, _zipCode);
        
    }
}