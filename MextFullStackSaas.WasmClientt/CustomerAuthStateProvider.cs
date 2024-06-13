using Blazored.LocalStorage;
using MextFullStackSaas.Application.Common.Models;
using MextFullStackSaas.Application.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace MextFullStackSaas.WasmClientt
{
    public class CustomerAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;

        public CustomerAuthStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var jwtDto = await _localStorageService.GetItemAsync<JwtDto>("cto");

            if (jwtDto is not null)
            {
                var claims = JwtHelper
                    .ReadClaimsFromToken(jwtDto.Token)
                    .Append(new Claim("Token", jwtDto.Token));

                var identity = new ClaimsIdentity(claims, "jwt");

                var user = new ClaimsPrincipal(identity);

                var state = new AuthenticationState(user);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtDto.Token);

                NotifyAuthenticationStateChanged(Task.FromResult(state));

                return state;
            }

            _httpClient.DefaultRequestHeaders.Authorization = null;

            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());

            return new AuthenticationState(anonymous);
        }
    }
}
