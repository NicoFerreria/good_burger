namespace GoodHamburger.Handlers;

public class DeleteOrder{
    public void Handle(string orderId){
        DataBase.Orders.RemoveAll(x => x.OrderId.ToString() == orderId);
    }
}