using GoodHamburger.Entities;

namespace GoodHamburger.DTOs;

public class SandwichesAndExtrasDTO {
    public List<Product> Sandwitches { get; set; }
    public List<ProductExtra> Extras { get; set; }    
}