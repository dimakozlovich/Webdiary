using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

               grade.IdentificationNumber = new Guid();
           
            
            
              using(var connection = new SqlConnection(DbHelper.connectionString))
               {
                   await connection.OpenAsync();

                    string sqlRequerst = $@"Insert into Grades (GradeName,GradeCreator_id,IdentificationNumber)
                                           Values(@GradeName, @GradeCreator_id,@IdentificationNumber)";

                   await connection.ExecuteAsync(sqlRequerst,grade);
               }         
            
            }

        }





    }
}
