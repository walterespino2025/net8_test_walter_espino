namespace Products.Domain.Product
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }= string.Empty;
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
    }
}
