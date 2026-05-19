using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace StudentDashboard.Web.Services;

public class DashboardAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal currentUser = new(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(currentUser));
    }
