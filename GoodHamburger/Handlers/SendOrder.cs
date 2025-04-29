using GoodHamburger.DTOs;
using GoodHamburger.Services.Interfaces;

namespace GoodHamburger.Handlers;

public class SendOrder
{
    private readonly IOrderService _service;

    public SendOrder(IOrderService service)
    {
        _service = service;
    }

    public OrderDTO Handle(ComboDTO order)
    {
        var newOrder = _service.SendOrderValidate(order);
        DataBase.Orders.Add(newOrder);

        return newOrder;
    }
}