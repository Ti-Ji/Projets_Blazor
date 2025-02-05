using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace ToDoApp.Web.Client;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
	public override Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		// Create an anonymous user
		var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
		return Task.FromResult(new AuthenticationState(anonymousUser));
	}

	public void NotifyUserAuthentication(ClaimsPrincipal user)
	{
		NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
	}

	public void NotifyUserLogout()
	{
		var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
		NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
	}
}