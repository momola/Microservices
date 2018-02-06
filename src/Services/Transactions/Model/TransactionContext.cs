
using System;
using Microsoft.EntityFrameworkCore;

public class TransactionContext : DbContext
{
    public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
    {

    }

    public DbSet<Transaction> TransactionsItem { get; set; }

}