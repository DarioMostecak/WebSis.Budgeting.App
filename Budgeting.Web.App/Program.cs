using Blazored.LocalStorage;
using Budgeting.Web.App;
using Budgeting.Web.App.Brokers.Apis;
using Budgeting.Web.App.Brokers.AuthenticationProviders;
using Budgeting.Web.App.Brokers.DateTimes;
using Budgeting.Web.App.Brokers.Loggings;
using Budgeting.Web.App.Brokers.NavigationBroker;
using Budgeting.Web.App.Services.Foundations;
using Budgeting.Web.App.Services.Foundations.Identity;
using Budgeting.Web.App.Services.Views.LoginViews;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddMudServices();

builder.Services.AddBlazoredLocalStorage();


builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationProviderBroker>();
builder.Services.AddScoped<AuthenticationStateProvider>(service => service.GetRequiredService<AuthenticationProviderBroker>());

#region Brokers
builder.Services.AddTransient<IApiBroker, ApiBroker>();
builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
builder.Services.AddTransient<INavigationBroker, NavigationBroker>();
builder.Services.AddScoped<IAuthenticationProviderBroker, AuthenticationProviderBroker>();
#endregion

#region Services
builder.Services.AddTransient<IIdentityService, IdentityService>();
builder.Services.AddTransient<ILoginViewService, LoginViewService>();
#endregion

builder.Services.AddHttpClient<IApiBroker, ApiBroker>();




await builder.Build().RunAsync();
