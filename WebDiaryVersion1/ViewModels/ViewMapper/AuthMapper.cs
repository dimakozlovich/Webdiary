﻿using WebDiaryVersion1.ViewModels;
using WebDiaryVersion1.DLL.Models_DLL;
namespace WebDiaryVersion1.ViewMapper
{
	public class AuthMapper
	{
		public static UserModel MapRegisterViewModelToUserModel(RegisterViewModel model)
		{
			return new UserModel()
			{
				Email = model.Email!,
			    Password = model.Password!
			};
		}
	}
}
