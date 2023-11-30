using System;
namespace WebDiaryVersion1.BL.Auth
{
	public interface ICurrentUser
	{
		Task<bool> IsLoggedIn();
	}
}

