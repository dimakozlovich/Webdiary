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
        private readonly IDbSession dbSession;
        public MainPageController(ILogger<HomeController> logger,
                                    ICurrentUser currentUser, 
                                    IMainPageBL mainPageBL,
                                    IDbSession dbSession)
        {
            this.logger = logger;
            this.currentUser = currentUser;
            this.mainPageBL = mainPageBL;
            this.dbSession = dbSession;
        }
		[HttpGet]
		public async Task<IActionResult> Index()
        {
            bool isLoggedIn = await currentUser.IsLoggedIn();
            if (isLoggedIn)
            {

                var userId = (int)await dbSession.GetUserId();
                Grade? grade = await mainPageBL.GetUsersGrade(userId);
                if (grade != null)
                    return View(mainPageBL.GetCurrentWeek(grade));
                else
                    return View("Join",new ViewModels.JoinToGradeViewModel());

            }
            else
            return View(null);
        }
        [HttpPost]
        public void Index(ViewModels.JoinToGradeViewModel model)
        {

        }
        [HttpGet]
		[Route("/join")]
		public async Task<IActionResult> Join()
        {
            if (!(await currentUser.IsLoggedIn()))
                return View(null);
            else
                return View(new ViewModels.JoinToGradeViewModel());
        }

        [HttpPost]
		[Route("/join")]
		public async Task<IActionResult> Join(string guid)
        {

            Guid _Guid = new Guid(guid);
            //Guid guid = model.ConvertStringToGuid();

            if(await mainPageBL.IsExist(_Guid))
            {
              var userId = (int)await dbSession.GetUserId();
			  await mainPageBL.SetGradeToUser(_Guid,userId);
			  Grade? grade = await mainPageBL.GetUsersGrade(userId) ?? new Grade();
			  return View("Index", mainPageBL.GetCurrentWeek(grade));
            }
            else
            {
                return View(null);
            }
        }
    }
}
