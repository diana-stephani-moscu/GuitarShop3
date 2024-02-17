using Microsoft.AspNetCore.Identity;
namespace GuitarShop.Models
{
    public class Guitar
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Colour { get; set; }

        public string Shape { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        //public byte[] Image { get; set; }
    }
}
