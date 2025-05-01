using GoodHamburger.DTOs;
using GoodHamburger.Entities;

namespace GoodHamburger;

public static class DataBase {
    public static SandwichesAndExtrasDTO productsAndExtrasDTO = new SandwichesAndExtrasDTO(){
         Sandwitches = new List<Product>() {
            new(){Name = "X Burger", Price = 5.0M},
            new(){Name = "X Egg", Price = 4.5M},
            new(){Name = "X Bacon", Price = 7.0M}
         },
         Extras = new List<ProductExtra>(){
            new(){Name = "Fries", Price = 2.0M},
            new(){Name = "Soft drink", Price = 2.5M}
         }
         //teste
    };   
    public static List<OrderDTO> Orders = [];        
}