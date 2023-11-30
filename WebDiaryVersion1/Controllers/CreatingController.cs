using Microsoft.AspNetCore.Mvc;

namespace WebDiaryVersion1.Controllers
{
    public class CreatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
