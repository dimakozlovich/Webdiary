using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDiaryVersion1.DLL.Models_DLL;

namespace WebDiaryVersion1.DLL
{
    public interface IMainPageDALL
    {
        Task<Grade> GetGrade(int grade_id);

        Task UpdateThisWeek(string[,,] week, Grade grade);
        Task UpdateLastWeek(string[,,] week, Grade grade);
        Task UpdateNextWeek(string[,,] week, Grade grade);

        string[,,] GetCurrentWeek(Grade grade);

        Task CreateGrade(Grade createdGrade);

        Task<bool> IsExist(Guid guid);

		Task SetGradeToUser(Guid guid, int userId);

        Task<Grade?> GetUsersGrade(int user_id);


	}

}
