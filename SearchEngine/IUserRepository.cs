using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine
{
    public interface IUserRepository
    {
        List<IUser> FindBy(string keyword);

        void SaveNewUser(string userName, List<string> profile);
    }
}
