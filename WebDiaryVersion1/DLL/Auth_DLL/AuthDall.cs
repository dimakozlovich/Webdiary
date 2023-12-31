﻿using Dapper;
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
							    values('{model.Email}', '{model.Password}','{model.Salt}')
                                SELECT SCOPE_IDENTITY() as Id";
                //var sqlCommand = new SqlCommand(sql, connection);
                var id = await connection.QueryFirstOrDefaultAsync<int>(sql);
                return Convert.ToInt32(id);
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

	}
}
