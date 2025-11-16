using Microsoft.AspNetCore.Components.Routing;

namespace Arya.TaskRoute.WebApplication.Models;

public class AppNavModel
{
    public required string Title { get; set; }
    public required string Url { get; set; }
    public required string Name { get; set; }
    public int Order { get; set; }
    public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;
    public bool OnBottom { get; set; } = false;
}