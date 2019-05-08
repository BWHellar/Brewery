using Microsoft.AspNetCore.Mvc;


namespace Brewery.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}