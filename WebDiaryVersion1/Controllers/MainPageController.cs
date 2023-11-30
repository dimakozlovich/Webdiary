using Microsoft.AspNetCore.Mvc;
using WebDiaryVersion1.BL;
using WebDiaryVersion1.BL.Auth;

namespace WebDiaryVersion1.Controllers
{
	public class MainPageController : Controller
	{
        private readonly ILogger<HomeController> logger;
        private readonly ICurrentUser currentUser;
        private readonly IMainPageBL mainPageBL;

        public MainPageController(ILogger<HomeController> logger, ICurrentUser currentUser, IMainPageBL mainPageBL)
        {
            this.logger = logger;
            this.currentUser = currentUser;
            this.mainPageBL = mainPageBL;
        }
        public async Task<IActionResult> Index()
        {
            bool isLoggedIn = await currentUser.IsLoggedIn();

            if (isLoggedIn)
            {
                Grade grade = await mainPageBL.GetGrade(1);
                string[,,] data = mainPageBL.GetCurrentWeek(grade);

                var test = data[1, 1, 1];

                return View(data);
            }
            else
                return View(null);
        }

    }
}
