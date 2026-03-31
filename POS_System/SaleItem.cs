namespace POS_system
{
    // Simple model used by Sales and receipt generation.
    public class SaleItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
    }
}