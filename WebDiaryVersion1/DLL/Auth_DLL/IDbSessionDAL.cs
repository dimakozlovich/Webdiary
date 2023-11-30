

namespace WebDiaryVersion1.DLL.Auth_DLL
{
	public interface IDbSessionDAL
	{
		Task<SessionModel?> GetSession(Guid sessionId);

		Task<int> UpdateSession(SessionModel model);

		Task<int> CreateSession(SessionModel model);
		
	}
}
