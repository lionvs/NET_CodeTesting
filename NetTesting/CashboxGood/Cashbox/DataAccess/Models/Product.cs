namespace Cashbox.DataAccess.Models
{
    internal class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}