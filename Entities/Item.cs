using SuprDaily.Entities.Enums;

namespace SuprDaily.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int Quantities { get; set; }
    }
}