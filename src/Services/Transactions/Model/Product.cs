public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }


    public Product(int ProductId, string ProductName, decimal ProductPrice)
    {
        this.ProductId = ProductId;
        this.ProductName = ProductName;
        this.ProductPrice = ProductPrice;
    }
}