public record PropertyResponseDto 
{   
    public Guid Id { get; init; }
    public string Title { get; init; }
    public double ValueRent { get; init; }
    public double ValueSale { get; init; }
    public Guid OwnerId { get; init; }
    public string Address { get; init; }
    public string Neighborhood { get; init; }
    public string Number { get; init; }
    public string Complement { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string ZipCode { get; init; }
    public string Description { get; init; }
    public double? Latitude { get; init; }
    public double? Longitude { get; init; }
    
    public PropertyResponseDto(PropertyModel propertyModel) {
        Id = propertyModel.Id;
        Title = propertyModel.Title;
        ValueRent = propertyModel.ValueRent;
        ValueSale = propertyModel.ValueSale;
        OwnerId = propertyModel.OwnerId;
        Address = propertyModel.Address;
        Neighborhood = propertyModel.Neighborhood;
        Number = propertyModel.Number;
        Complement = propertyModel.Complement;
        City = propertyModel.City;
        State = propertyModel.State;
        ZipCode = propertyModel.ZipCode;
        Description = propertyModel.Description;
        Latitude = propertyModel.Latitude;
        Longitude = propertyModel.Longitude;
    }
}