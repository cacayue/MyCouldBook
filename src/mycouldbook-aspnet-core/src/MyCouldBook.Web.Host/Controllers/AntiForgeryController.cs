using Microsoft.AspNetCore.Antiforgery;
using MyCouldBook.Controllers;

namespace MyCouldBook.Web.Host.Controllers
{
    public class AntiForgeryController : MyCouldBookControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
