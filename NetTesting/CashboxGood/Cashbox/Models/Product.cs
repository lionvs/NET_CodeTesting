using Cashbox.DataAccess;

namespace Cashbox.Models
{
    internal class Product : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}