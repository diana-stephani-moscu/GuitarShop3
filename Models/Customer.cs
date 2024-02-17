namespace GuitarShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<CartItem> CartItem { get; set; }
    }
}
