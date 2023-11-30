using Dapper;
using Microsoft.Data.SqlClient;

namespace WebDiaryVersion1.DLL.Auth_DLL
{
    public class AuthDall : IAuthDall
    {
        async Task<int> IAuthDall.CreateUser(UserModel model)
        {
            using (var connection = new SqlConnection(DbHelper.connectionString))
            {
                await connection.OpenAsync();
                string sql = $@"insert into AppUser(Email, Password,Salt)
							   values('{model.Email}', '{model.Password}','{model.Salt}')";
                var sqlCommand = new SqlCommand(sql, connection);
                return await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        async Task<UserModel> IAuthDall.GetUser(string email)
        {
            using (var connection = new SqlConnection(DbHelper.connectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(@"select *
																from AppUser 
																where Email = @user_email", new { user_email = email }) ?? new UserModel();//incorect SQL request
            }
        }

        async Task<UserModel> IAuthDall.GetUser(int id)
        {
            using (var connection = new SqlConnection(DbHelper.connectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(@"select USER_ID, Name, Mail, Parole
																from AppUser 
																where UserId = @user_id", new { user_id = id }) ?? new UserModel();//incorect SQL request
            }
            throw new NotImplementedException();
        }
		async Task IAuthDall.SetGradeToUser(System.Guid guid, int userId)
		{
            using(var connection = new SqlConnection(DbHelper.connectionString))
            {
                await connection.OpenAsync();

                string sqlQuery = $@"Update AppUser
                                     set Grade_id = (select Grade_id from Grades where identificationNumber = '{guid}')
                                     where UserId = {userId}";
                await connection.ExecuteAsync(sqlQuery);
            }
        }

	}
}
