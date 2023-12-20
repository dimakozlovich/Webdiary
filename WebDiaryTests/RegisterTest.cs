using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDiaryTests.Helpers;

namespace WebDiaryTests
{
    public class RegisterTest : BaseTest
    {
        [Fact]
        public async Task BaseRegistrationTest()
        {
            string email = Guid.NewGuid().ToString() + "@test.com";

            // validate: should not be in the DB
            var emailValidationResult = await authBL.ValidateEmail(email);
            Assert.Null(emailValidationResult);

            int user_id = await authBL.CreateUser(
                new WebDiaryVersion1.DLL.Models_DLL.UserModel()
                {
                    Email = email,
                    Password = "testpassword"
                }
                ) ;

            Assert.NotEqual(expected: 0, user_id);

            emailValidationResult = await authBL.ValidateEmail(email);
            Assert.NotNull(emailValidationResult);
        }
    }
}
