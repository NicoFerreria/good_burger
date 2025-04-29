using GoodHamburger.DTOs;

namespace GoodHamburger.Services.Interfaces;

public interface IOrderService
{
    OrderDTO SendOrderValidate(ComboDTO order);    
}