using System.Collections.Generic;

public class Transaction
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string TransactionOwner { get; set; }
    public List<Product> ProductsList { get; set; }

    public Transaction(int Id, string Title, string TransactionOwner, List<Product> ProductsList)
    {
        this.Id = Id;
        this.Title = Title;
        this.TransactionOwner = TransactionOwner;
        this.ProductsList = ProductsList;
    }

    public Transaction() { }

}


