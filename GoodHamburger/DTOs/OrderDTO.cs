namespace GoodHamburger.DTOs;

public class OrderDTO {
    public Guid OrderId { get; set; }
    public List<ComboDTO> Sandwiches { get; set; } = [];
    public decimal Amount { get; set; }
}