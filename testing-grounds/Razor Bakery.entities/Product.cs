namespace Razor_Bakery.entities
{
    public class Product
    {
        private int id;
        private string name;
        private string description;
        private decimal price;
        private string imageName;

        public Product() { }

        public Product(int id, string name, string description, decimal price, string imageName)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ImageName = imageName;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public decimal Price { get => price; set => price = value; }
        public string ImageName { get => imageName; set => imageName = value; }
    }
}
