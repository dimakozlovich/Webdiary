using Microsoft.AspNetCore.Mvc;
using WebDiaryVersion1.BL;
using WebDiaryVersion1.BL.Auth;
using WebDiaryVersion1.ViewMapper;
using WebDiaryVersion1.ViewModels;

namespace WebDiaryVersion1.Controllers
{
    public class CreatingController : Controller
    {
        private readonly IDbSession dbSession;
        private readonly ICurrentUser currentUser;
        private readonly IMainPageBL mainPageBL;



        public CreatingController(IDbSession dbSession,ICurrentUser currentUser, IMainPageBL mainPageBL)
        {
            this.dbSession = dbSession;
            this.mainPageBL = mainPageBL;
            this.currentUser = currentUser;
        }


        [HttpGet]
        [Route("/creating")]
        public async Task<IActionResult> Index()
        {
            if (await currentUser.IsLoggedIn())
            {
                return View(new ViewModels.CreatingGradeViewModel());
            }
            else
            {
                return View(null); 
            }

        }

        [HttpPost]
        [Route("/creating")]
        public async Task<IActionResult> Index(CreatingGradeViewModel createdGrade)
        {
            if(ModelState.IsValid)
            {
                Grade grade = AuthMapper.MapCreatedGradeModelToGrade_DaLLModel(createdGrade);
                var user_Id = await dbSession.GetUserId();

                if(user_Id != null)
                {
                    grade.GradeCreator_id = (int)user_Id;
                }

                await mainPageBL.CreateGrade(grade);

                return Redirect("/");
            }
            return View();
        }
    }
}
