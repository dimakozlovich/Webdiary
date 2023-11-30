

namespace WebDiaryVersion1.BL
{
    public interface IMainPageBL
	{
		string[,,] GetCurrentWeek(Grade grade);

		Task<Grade> GetGrade(int id);

		Task CreateGrade(Grade grade);

		Task<bool> IsExist(Guid guid);
		
	}
}
