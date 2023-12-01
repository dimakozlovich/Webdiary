using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDiaryVersion1.DLL.Auth_DLL;
using WebDiaryVersion1.DLL.Models_DLL;

namespace WebDiaryVersion1.DLL
{ 
	public class MainPageDALL : IMainPageDALL
    {
        public async Task<Grade> GetGrade(int id)
        {
            using (var connection = new SqlConnection(DbHelper.connectionString))
            {
                await connection.OpenAsync();

                var sqlQueryGetGrade = $@"select * from Grades where Grade_id = {id}";

                var grade = await connection.QueryFirstAsync<Grade>(sqlQueryGetGrade);
                if (grade != null)
                    return grade;
                else
                    return new Grade();
            }

        }

        public async Task UpdateLastWeek(string[,,] week, Grade grade)
        {
            using (var connection = new SqlConnection(DbHelper.connectionString))
            {
                await connection.OpenAsync();

                var toJsonWeek = JsonConvert.SerializeObject(week);

                var sqlQueryUpdateLastWeek = @$"update Grades
												set Last_week = {toJsonWeek}
												where Grade_id = {grade.Grade_id}";

                await connection.ExecuteAsync(sqlQueryUpdateLastWeek);
            }
        }

        public async Task UpdateNextWeek(string[,,] week, Grade grade)
        {
            using (var connection = new SqlConnection(DbHelper.connectionString))
            {
                await connection.OpenAsync();

                var toJsonWeek = JsonConvert.SerializeObject(week);

                var sqlQueryUpdateLastWeek = @$"update Grades
												set Next_week = {toJsonWeek}
												where Grade_id = {grade.Grade_id}";

                await connection.ExecuteAsync(sqlQueryUpdateLastWeek);
            }
        }

        public async Task UpdateThisWeek(string[,,] week, Grade grade)
        {
            using (var connection = new SqlConnection(DbHelper.connectionString))
            {
                await connection.OpenAsync();

                var toJsonWeek = JsonConvert.SerializeObject(week);

                var sqlQueryUpdateLastWeek = @$"update Grades
												set This_week = {toJsonWeek}
												where Grade_id = {grade.Grade_id}";

                await connection.ExecuteAsync(sqlQueryUpdateLastWeek);
            }
        }

        public string[,,]? GetCurrentWeek(Grade grade)
        {
            return grade.GetThisWeek();
        }

        public async Task CreateGrade(Grade createdGrade)
        {
            if (createdGrade.GradeName != null)
            {
               var grade = new Grade();

               grade.GradeName = createdGrade.GradeName;

               grade.GradeCreator_id = createdGrade.GradeCreator_id;

                grade.IdentificationNumber = Guid.NewGuid();
           
            
            
              using(var connection = new SqlConnection(DbHelper.connectionString))
               {
                   await connection.OpenAsync();

                    string sqlRequerst = $@"Insert into Grades (GradeName,GradeCreator_id,IdentificationNumber)
                                           Values(@GradeName, @GradeCreator_id,@IdentificationNumber)";

                   await connection.ExecuteAsync(sqlRequerst,grade);
               }         
            
            }

        }
		public async Task<bool> IsExist(Guid guid)
        {
            using(var connection = new SqlConnection(DbHelper.connectionString)) 
            {
               await connection.OpenAsync();

                string sqlRequest = @$"select Grade_id from Grades
                                       where IdentificationNumber ='{guid}'";
                var gradeId = await connection.QueryAsync<int>(sqlRequest);

                return gradeId != null;
            }
        }
		public async Task SetGradeToUser(System.Guid guid, int userId)
		{
			using (var connection = new SqlConnection(DbHelper.connectionString))
			{
				await connection.OpenAsync();

				string sqlQuery = $@"Update AppUser
                                     set Grade_id = (select Grade_id from Grades where identificationNumber = '{guid}')
                                     where UserId = {userId}";
				await connection.ExecuteAsync(sqlQuery);
			}
		}
        public async Task<Grade?> GetUsersGrade(int user_id)
		{
            using(var connection = new SqlConnection(DbHelper.connectionString))
            {
                await connection.OpenAsync();

                string sqlQery = $@"select * from Grades where Grade_id = (select Grade_id from AppUser where UserId = {user_id})";

                Grade? grade = await connection.QueryFirstOrDefaultAsync<Grade>(sqlQery);

                return grade;
            }
        }


	}
}
