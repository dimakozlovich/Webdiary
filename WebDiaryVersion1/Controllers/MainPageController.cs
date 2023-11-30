using Microsoft.AspNetCore.Mvc;
using WebDiaryVersion1.BL;
using WebDiaryVersion1.BL.Auth;
using WebDiaryVersion1.DLL.Models_DLL;

namespace WebDiaryVersion1.Controllers
{
	public class MainPageController : Controller
	{
        private readonly ILogger<HomeController> logger;
        private readonly ICurrentUser currentUser;
        private readonly IMainPageBL mainPageBL;
        private readonly IAuthBL authBL;
        private readonly IDbSession dbSession;
        public MainPageController(ILogger<HomeController> logger,
                                    ICurrentUser currentUser, 
                                    IMainPageBL mainPageBL,
                                    IAuthBL authBL,
                                    IDbSession dbSession)
        {
            this.logger = logger;
            this.currentUser = currentUser;
            this.mainPageBL = mainPageBL;
            this.authBL = authBL;
            this.dbSession = dbSession;
        }
        public async Task<IActionResult> Index()
        {
            bool isLoggedIn = await currentUser.IsLoggedIn();

            if (isLoggedIn)
            {
				var userId = (int)await dbSession.GetUserId();

				Grade grade = await mainPageBL.GetGrade(userId);
                string[,,] data = mainPageBL.GetCurrentWeek(grade);
                return View(data);
            }
            else
                return View(null);
        }
        [HttpGet]
        public async Task<IActionResult> Join()
        {
            if (!(await currentUser.IsLoggedIn()))
                return View(null);
            else
                return View(new ViewModels.JoinToGradeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Join(ViewModels.JoinToGradeViewModel model)
        {
            if(await mainPageBL.IsExist(model.guid))
            {
              var userId = (int)await dbSession.GetUserId();
			  await authBL.SetGradeToUser(model.guid,userId);
			  Grade grade = await mainPageBL.GetGrade(userId);
			  return View("MainPage/Index", mainPageBL.GetCurrentWeek(grade));
            }
            else
            {
                return View(null);
            }
        }
    }
}
