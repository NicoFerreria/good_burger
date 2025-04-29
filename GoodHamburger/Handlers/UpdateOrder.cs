using GoodHamburger.DTOs;
using GoodHamburger.Services.Interfaces;

namespace GoodHamburger.Handlers;

public class UpdateOrder
{

    private readonly IOrderService _service;

    public UpdateOrder(IOrderService service)
    {
        _service = service;
    }
    public decimal Handle(string orderId, ComboDTO order)
    {
        DataBase.Orders.RemoveAll(x => x.OrderId.ToString() == orderId);
        OrderDTO newOrder = _service.SendOrderValidate(order);
        DataBase.Orders.Add(newOrder);
        return newOrder.Amount;
    }
}