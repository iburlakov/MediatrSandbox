using Microsoft.AspNetCore.Mvc;

namespace MediatrSandbox.Api.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
