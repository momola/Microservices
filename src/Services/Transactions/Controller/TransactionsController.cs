using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class TransactionController : Controller
{
    private readonly TransactionContext _context;

    public TransactionController(TransactionContext context)
    {

        _context = context;
        int ixx= _context.TransactionsItem.Count();
        if (ixx == 0)
        {
            _context.TransactionsItem.Add(new Transaction { Id = 1, Title = "xx", TransactionOwner = "KowalskiJan", ProductsList = new List<Product>() { new Product(1, "xx", 23300) } });
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public JsonResult GetAll()
    {
        return Json(_context.TransactionsItem.ToList());
    }
    [HttpGet("{id}", Name = "GetTransaction")]
    public JsonResult GetById(int id)
    {
        var item = _context.TransactionsItem.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {

            return Json(new { message = "bad request"});
        }

        return Json((item));

    }

    [HttpPost]
    public IActionResult Create([FromBody] Transaction item)
    {
        if (item == null)
        {

            return BadRequest();
        }
        _context.TransactionsItem.Add(item);
        _context.SaveChanges();

        return CreatedAtRoute("GetTransaction", new { Id = item.Id }, item);
    }

    [HttpPut ("{id}")]
    public IActionResult Update(int id, [FromBody] Transaction item)
    {
        if (item == null || item.Id!= id)
        {
            return BadRequest();
        }
        var transaction = _context.TransactionsItem.FirstOrDefault(t => t.Id == id);
        if (transaction == null)
        {
            return NotFound();
        }
        transaction.Title = item.Title;
        transaction.TransactionOwner = item.TransactionOwner;
        transaction.ProductsList = item.ProductsList;

        _context.TransactionsItem.Update(transaction);
        _context.SaveChanges();

        return new NoContentResult();
    }


    [HttpDelete]
    public IActionResult Delete(int id)
    {

        var transaction = _context.TransactionsItem.FirstOrDefault(t => t.Id == id);
        if (transaction == null)
        {
            return NotFound();

        }
        _context.TransactionsItem.Remove(transaction);
        _context.SaveChanges();
        return new NoContentResult();

    }

}