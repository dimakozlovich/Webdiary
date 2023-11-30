using Microsoft.AspNetCore.Mvc;
using WebDiaryVersion1.BL.Auth;

namespace WebDiaryVersion1.Controllers
{
    public class LoginController : Controller
    {
     
    private readonly IAuthBL authBL;
            public LoginController(IAuthBL authBL)
            {
                this.authBL = authBL;
            }
            [HttpGet]
            [Route("/login")]
            public IActionResult Index()
            {
                return View("Index", new ViewModels.LoginViewModel());
            }
            [HttpPost]
            [Route("/login")]
            public async Task<IActionResult> IndexSave(ViewModels.LoginViewModel model)
            {
                if (ModelState.IsValid)
                {
                try
                {
                    await authBL.Authenticate(model.Email!, model.Password!, model.RememberMe!);
                    return Redirect("/");
                }
                catch
                {
					ModelState.AddModelError("Email", "Имя или Email неверные");
				}
                }
                return View("Index", new ViewModels.LoginViewModel());
            }
       
    }
}
