using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using ToDoApp.Web;
using ToDoApp.Web.Client;
using ToDoApp.Web.Components;
using _Imports = ToDoApp.Web.Client._Imports;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();
builder.Services.AddFluentUIComponents();

builder.Services.AddHttpClient("ToDoApp.API", client => client.BaseAddress = new Uri("https://localhost:7008/"));

// Add authentication services
builder.Services.AddAuthentication(
	options =>
	{
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	}).AddJwtBearer(
	options =>
	{
		var key = Encoding.ASCII.GetBytes(
			AuthSettings.PrivateKey); // Replace with a secure key from a configuration source

		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateLifetime = true,
			IssuerSigningKey = new SymmetricSecurityKey(key)
		};

		options.Events = new JwtBearerEvents
		{
			OnAuthenticationFailed = context =>
			{
				Console.WriteLine("Authentication failed: " + context.Exception.Message);
				return Task.CompletedTask;
			}
		};
	});


builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { app.UseWebAssemblyDebugging(); }
else
{
	app.UseExceptionHandler("/Error", true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode().AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(_Imports).Assembly);

await app.RunAsync();