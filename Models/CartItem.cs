namespace GuitarShop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int GuitarId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
