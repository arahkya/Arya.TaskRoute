using Arya.TaskRoute.WebApplication.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Arya.TaskRoute.WebApplication;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddSingleton<AppRootModel>(options =>
        {
            var appRootModel = new AppRootModel();
            appRootModel.MainNavItems = new List<AppNavModel>
            {
                new AppNavModel { Title = "Home", Url = "/", Name = "home", Order = 1, IsActive = true, Match = Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All },
                new AppNavModel { Title = "Tasks", Url = "/tasks", Name = "tasks", Order = 2 },
                new AppNavModel { Title = "Plan", Url = "/plan", Name = "plan", Order = 3 },
                new AppNavModel { Title = "People", Url = "/people", Name = "people", Order = 4 },
                new AppNavModel { Title = "Calendar", Url = "/calendar", Name = "calendar", Order = 5 },
                new AppNavModel { Title = "Dependencies", Url = "/dependencies", Name = "dependencies", Order = 6 },
                new AppNavModel { Title = "Settings", Url = "/settings", Name = "settings", Order = 7, OnBottom = true },
                new AppNavModel { Title = "Help", Url = "/help", Name = "help", Order = 8, OnBottom = true },
            };

            return appRootModel;
        });

        var host = builder.Build();

        await host.RunAsync();
    }
}
