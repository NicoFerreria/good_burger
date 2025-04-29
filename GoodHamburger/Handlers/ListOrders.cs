using GoodHamburger.DTOs;

namespace GoodHamburger.Handlers;

public class ListOrders {

    public List<OrderDTO> Handle(){
        return DataBase.Orders;
    }
}