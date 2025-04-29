using GoodHamburger.DTOs;
using GoodHamburger.Exceptions;
using GoodHamburger.Services.Interfaces;

namespace GoodHamburger.Services;

public class OrderService : IOrderService
{
    private double ApplyDiscount(OrderDTO order)
    {
        double percentage = 0.0;
        var fries = order.Sandwiches[0].Extras.Any(x => x.Name == "Fries");
        var drink = order.Sandwiches[0].Extras.Any(x => x.Name == "Soft Drinks");
        var friesAndDrink = fries && drink;

        percentage = fries ? 0.1 : 0;
        if(percentage == 0) percentage = drink ? 0.15 : 0;
        percentage = friesAndDrink ? 0.2 / 100 : percentage;

        var value = order.Amount * (decimal)percentage;
        order.Amount -=  value;

        return percentage;
    }

    public OrderDTO SendOrderValidate(ComboDTO order)
    {
        decimal amountExtras = 0M;

        foreach(var orderExtra in order.Extras){
            var extra = DataBase.productsAndExtrasDTO.Extras.Find(x => x.Name.Equals(orderExtra.Name)) ?? throw new NotFoundException("Record not found");
            var quantityItens = order.Extras.Count(x => x.Name.Equals(orderExtra.Name, StringComparison.OrdinalIgnoreCase));
            if(quantityItens > 1) throw new BusinessException("There are duplicate extras itens!");            
            amountExtras += extra.Price;
        }
        
        var combo = DataBase.productsAndExtrasDTO.Sandwitches.Find(x => x.Name.Equals(order.Name, StringComparison.OrdinalIgnoreCase)) ?? throw new NotFoundException("Record not found");
        
        OrderDTO newOrder = new()
        {
            OrderId = Guid.NewGuid()
        };
        newOrder.Sandwiches.Add(order);
        newOrder.Amount = combo.Price + amountExtras;
        ApplyDiscount(newOrder);
        return newOrder;
    }
}