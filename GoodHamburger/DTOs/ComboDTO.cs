namespace GoodHamburger.DTOs;

public class ComboDTO: OrderItemDTO {
    public List<OrderItemDTO> Extras { get; set; }
}