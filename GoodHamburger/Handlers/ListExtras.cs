using GoodHamburger.Entities;

namespace GoodHamburger.Handlers;

public class ListExtras {
    public List<ProductExtra> Handle(){
        return DataBase.productsAndExtrasDTO.Extras;
    }
}