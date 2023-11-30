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

        private readonly IMainPageBL mainPageBL;



        public CreatingController(IDbSession dbSession, IMainPageBL mainPageBL)
        {
            this.dbSession = dbSession;
            this.mainPageBL = mainPageBL;
        }


        [HttpGet]
        [Route("/creating")]
        public IActionResult Index()
        {
            return View(new ViewModels.CreatingGradeViewModel());
        }

        [HttpPost]
        [Route("/creating")]
        public async Task<IActionResult> Index(CreatingGradeViewModel createdGrade)
        {
            if(ModelState.IsValid)
            {
                Grade grade = AuthMapper.MapCreatedGradeModelToGrade_DaLLModel(createdGrade);
                grade.GradeCreator_id = await dbSession.GetUserId() ?? 0;
                await mainPageBL.CreateGrade(grade);

                return Redirect("/");
            }
            return View();
        }
    }
}
