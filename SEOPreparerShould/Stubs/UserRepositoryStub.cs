using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEO.Tests.Stubs
{
    public class UserRepositoryStub : IUserRepository
    {
        public List<IUser> users;

        public List<IUser> FindBy(string keyword)
        {
            return users;
        }

        public void SaveNewUser(string userName, List<string> profile)
        {
            throw new NotImplementedException();
        }
    }
}
