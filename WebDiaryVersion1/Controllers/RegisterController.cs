using Microsoft.AspNetCore.Mvc;
using WebDiaryVersion1.BL.Auth;
using WebDiaryVersion1.ViewMapper;

namespace WebDiaryVersion1.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IAuthBL authBL;
		public RegisterController(IAuthBL authBL)
		{
			this.authBL = authBL;
		}
		[HttpGet]
		[Route("/register")]
		public IActionResult Index()
		{
			return View("Index", new ViewModels.RegisterViewModel());
		}
		[HttpPost]
		[Route("/register")]
		public async Task<IActionResult> IndexSave(ViewModels.RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{ 
				await authBL.CreateUser(AuthMapper.MapRegisterViewModelToUserModel(model));
				return Redirect("/");
			}
			return View("Index", new ViewModels.RegisterViewModel());
		}
	}
}
