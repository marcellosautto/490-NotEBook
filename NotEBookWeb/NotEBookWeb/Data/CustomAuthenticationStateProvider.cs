using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotEBookWeb.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }
        //called when loading application for first time
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var email = await _sessionStorageService.GetItemAsync<string>("Email");
            ClaimsIdentity identity;

            if (email != null)
            {
                identity = new ClaimsIdentity(new[]
                 {
                new Claim(ClaimTypes.Name, email),
            }, "apiauth_type");

            }
            else
            {
                identity = new ClaimsIdentity();
            }
            
            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void FlagUserAsAuthenticated(string email)
        {

            var identity = new ClaimsIdentity(new[]
                 {
                new Claim(ClaimTypes.Name, email),
            }, "apiauth_type");

            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void FlagUserAsLoggedOut()
        {
            _sessionStorageService.RemoveItemAsync("Email");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
