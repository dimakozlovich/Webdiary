

namespace WebDiaryVersion1.BL
{
    public interface IMainPageBL
	{
		string[,,] GetCurrentWeek(Grade grade);

		Task<Grade> GetGrade(int id);

		Task CreateGrade(Grade grade);

		Task<bool> IsExist(Guid guid);
		Task SetGradeToUser(Guid guid, int userId);

		Task<Grade?> GetUsersGrade(int user_id);
	}
}
