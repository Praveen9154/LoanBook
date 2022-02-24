using Microsoft.AspNetCore.Mvc;
using loanbook.Models;
namespace loanbook.Controllers
{
    public class SubCluientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/SubClient/addition")]
        public Customer addition(Customer ce)
        {
            kbookContext kcc = new kbookContext();
            kcc.Add(ce);
            kcc.SaveChanges();
            return ce;
        }

    }
}
