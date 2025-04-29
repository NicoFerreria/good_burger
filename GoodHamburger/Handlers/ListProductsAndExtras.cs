using GoodHamburger.DTOs;

namespace GoodHamburger.Handlers;

public class ListSandwichesAndExtras {
    public SandwichesAndExtrasDTO Handle(){
        return DataBase.productsAndExtrasDTO;
    }

}