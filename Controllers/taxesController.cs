using Microsoft.AspNetCore.Mvc;
using loanbook.Models;
namespace loanbook.Controllers
{
    public class taxesController : Controller
    {
        [HttpPost]
        [Route("api/taxes/addition")]
        public Taxis addition(Taxis tx)
        {
            kbookContext kcc = new kbookContext();
            kcc.Add(tx);
            kcc.SaveChanges();
            return tx;
        }

        [HttpPost]
        [Route("api/taxes/updation")]
        public Taxis updation(Taxis tx)
        {
            kbookContext kcc = new kbookContext();
            var ld = kcc.Taxes.Where(a => a.TxnId == tx.TxnId).FirstOrDefault();
            ld.ProductName = tx.ProductName;
            ld.Quantity = tx.Quantity;
            ld.Price = tx.Price;
            kcc.SaveChanges();
            return tx;
        }

        [HttpPost]
        [Route("api/taxes/deletion")]
        public Taxis deletion(Taxis tx)
        {
            kbookContext kcc = new kbookContext();
            var ld = kcc.Taxes.Where(a => a.TxnId == tx.TxnId).FirstOrDefault();
            kcc.Remove(tx);
            kcc.SaveChanges();
            return tx;
        }
    }
}
