using System.ComponentModel.DataAnnotations;

namespace WebDiaryVersion1.DLL.Auth_DLL
{
    public interface IAuthDall
    {
        Task<UserModel> GetUser(string email);

        Task<UserModel> GetUser(int id);

        Task<int> CreateUser(UserModel model);

		Task SetGradeToUser(Guid guid, int userId);
    }
}
