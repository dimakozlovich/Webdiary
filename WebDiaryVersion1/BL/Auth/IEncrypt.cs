using System;
namespace WebDiaryVersion1.BL.Auth
{
	public interface IEncrypt
	{
		string HashPassword(string password, string salt);
	}
}

