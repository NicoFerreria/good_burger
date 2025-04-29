using GoodHamburger.Entities;

namespace GoodHamburger.Handlers;

public class ListSandwiches{
    public List<Product> Handle(){
        return DataBase.productsAndExtrasDTO.Sandwitches;
    }
}