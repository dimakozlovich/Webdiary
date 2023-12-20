using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDiaryVersion1.BL.Auth;
using WebDiaryVersion1.DLL.Auth_DLL;

namespace WebDiaryTests.Helpers
{
    public class BaseTest
    {
        protected IAuthDAL authDall = new AuthDAL();
        protected IEncrypt encrypt = new Encrypt();
        protected IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        protected IDbSessionDAL dbSessionDall = new DbSessionDAL();
        protected IDbSession dbSession;
        protected IAuthBL authBL;

        public BaseTest()
        {
            dbSession = new DbSession(dbSessionDall,httpContextAccessor);
            authBL = new AuthBL(authDall, encrypt, httpContextAccessor,dbSession);
        }


    }
}
