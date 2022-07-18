using Microsoft.AspNetCore.Components;

namespace BlazorWebECommerceApp.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly NavigationManager _navigationManager;

        public OrderService(
            HttpClient http,
            AuthenticationStateProvider authStateProvider,
            NavigationManager navigationManager)
        {
            _http = http;
            _authStateProvider = authStateProvider;
            _navigationManager = navigationManager;
        }
        public async Task PlaceOrder()
        {
            if(await IsUSerAuthenticated())
            {
                await _http.PostAsync("api/order", null);
            }
            else
            {
                _navigationManager.NavigateTo("login");
            }
        }

        private async Task<bool> IsUSerAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }
    }
}
