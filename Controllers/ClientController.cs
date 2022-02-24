using Microsoft.AspNetCore.Mvc;
using loanbook.Models;

namespace loanbook.Controllers
{
    public class ClientController : Controller
    {
  
        [HttpPost]
        [Route("api/client/addition")]
        public KbookClient addition(KbookClient kc)
        {
            kbookContext kcc = new kbookContext();
            kcc.Add(kc);
            kcc.SaveChanges();
            return kc;
        }

        [HttpPost]
        [Route("api/client/updation")]
        public KbookClient updation(KbookClient kc)
        {
            kbookContext kcc = new kbookContext();
            var ld = kcc.KbookClients.Where(a => a.KbookClientId == kc.KbookClientId).FirstOrDefault();
            ld.Name = kc.Name;
            ld.Phoneno = kc.Phoneno;
            ld.Status=kc.Status;
            kcc.SaveChanges();
            return kc;
        }

        [HttpPost]
        [Route("api/client/deletion")]
        public KbookClient deletion (KbookClient kc)
        {
            kbookContext kcc = new kbookContext();
            var ld = kcc.KbookClients.Where(a => a.KbookClientId == kc.KbookClientId).FirstOrDefault();
            kcc.Remove(kc);
            kcc.SaveChanges();
            return kc;
        }
    }
}
