using System;
using System.Collections.Generic;
using System.Text;

namespace SEO
{
    public interface IUserRepository
    {
        List<IUser> FindBy(string keyword);

        void SaveNewUser(string userName, List<string> profile);
    }
}
