﻿


namespace WebDiaryVersion1.BL
{
	public class MainPageBL : IMainPageBL
	{
		private readonly IMainPageDALL mainPageDALL;

		public MainPageBL(IMainPageDALL mainPageDALL)
		{
			this.mainPageDALL = mainPageDALL;
		}
		public string[,,] GetCurrentWeek(Grade grade)
		{
			return mainPageDALL.GetCurrentWeek(grade);
		}

		public async Task<Grade> GetGrade(int id)
		{
			return await mainPageDALL.GetGrade(id);
		}

		public async Task CreateGrade(Grade grade)
		{
			await mainPageDALL.CreateGrade(grade);
		}
		public async Task<bool> IsExist(Guid guid)
		{
			return await mainPageDALL.IsExist(guid);
		}
	}
}
