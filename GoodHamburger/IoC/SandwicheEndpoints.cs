using GoodHamburger.Handlers;

namespace GoodHamburger.IoC;

public static class SandwicheEndpoints {
    public static void AddSandwicheEndpoints(this WebApplication app){
        app.MapGet("/listSandwichesAndExtras", () =>
        {
            var handler = new ListSandwichesAndExtras();
            return TypedResults.Ok(handler.Handle());
        })
        .WithName("listSandwichesAndExtras")
        .WithDescription("List sandwiches and extras")
        .WithOpenApi();

        app.MapGet("/listSandwiches", () =>
        {
            var handler = new ListSandwiches();
            return TypedResults.Ok(handler.Handle());
        })
        .WithName("listSandwiches")
        .WithDescription("List sandwiches")
        .WithOpenApi();

         app.MapGet("/listExtras", () =>
        {
            var handler = new ListExtras();
            return TypedResults.Ok(handler.Handle());
        })
        .WithName("listExtras")
        .WithDescription("List extras")
        .WithOpenApi();
    }    
}