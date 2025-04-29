using GoodHamburger.Services;
using GoodHamburger.Services.Interfaces;

namespace GoodHamburger.IoC;


public static class ServicesIoC {
    public static void AddServices(this IServiceCollection services){
        services.AddScoped<IOrderService, OrderService>();
    }
}