using System.Runtime.Serialization;

[DataContract(Name="voice")]
public class Invoice
{
    [DataMember(Name="id")]
    public int Id { get; set; }

    [DataMember(Name="title")]
    public string Title { get; set; }

    [DataMember(Name="transactionOwner")]
    public string TransactionOwner { get; set; }

    
    
}