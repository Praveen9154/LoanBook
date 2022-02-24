using Microsoft.AspNetCore.Mvc;
using loanbook.Models;
namespace loanbook.Controllers
{
    public class customerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("api/customer/updation")]
        public Customer updation(Customer ce)
        {
            kbookContext kc = new kbookContext();
            var ld = kc.Customers.Where(a => a.CustomerId == ce.CustomerId).FirstOrDefault();
            ld.CusName = ce.CusName;
            ld.Phoneno = ce.Phoneno;
            ld.Status = ce.Status;
            ld.Ordertotal = ce.Ordertotal;
            kc.SaveChanges();
            return ce;
        }
        [HttpPost]
        [Route("api/customer/deletion")]
        public Customer deletion (Customer ce)
        {
            kbookContext kd = new kbookContext();   
            var ld= kd.Customers.Where(a=>a.CustomerId==ce.CustomerId).FirstOrDefault();
            kd.Remove(ce);
            return ce;
;        }

    }
}
