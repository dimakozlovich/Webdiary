using Dapper;
using Microsoft.Data.SqlClient;

namespace WebDiaryVersion1.DLL.Auth_DLL
{
	public class DbSessionDaLL : IDbSessionDAL
	{
		public async Task<int> CreateSession(SessionModel model)
		{
			using (var connection = new SqlConnection(DbHelper.connectionString))
			{
				await connection.OpenAsync();
				string sql = @"insert into DbSession (DbSessionID, SessionData, Created, LastAccessed, UserId)
                      values (@DbSessionID, @SessionContent, @Created, @LastAccessed, @UserId)";

				return await connection.ExecuteAsync(sql, model);
			}
		}

		public async Task<SessionModel?> GetSession(Guid sessionId)
		{
			using (var connection = new SqlConnection(DbHelper.connectionString))
			{
				await connection.OpenAsync();
				
				var sessions = await connection.QueryFirstOrDefaultAsync<SessionModel>(@"select DbSessionID, SessionData, Created, LastAccessed, UserId	
																								from DbSession	
																								where DbSessionID = @sessionId", new { sessionId = sessionId });
				
				return sessions;
			}
		}

		public async Task<int> UpdateSession(SessionModel model)
		{
			using (var connection = new SqlConnection(DbHelper.connectionString))
			{
				await connection.OpenAsync();
				string sql = @"update DbSession
                      set SessionData = @SessionData, LastAccessed = @LastAccessed, UserId = @UserId
                      where DbSessionID = @DbSessionID
                ";

				return await connection.ExecuteAsync(sql, model);
			}
		}
	}
}
