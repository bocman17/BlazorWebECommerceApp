namespace BlazorWebECommerceApp.Client.Services.AddressService
{
    public interface IAdressService
    {
        Task<Address> GetAddress();
        Task<Address> AddOrUpdateAddress(Address address);
    }
}
