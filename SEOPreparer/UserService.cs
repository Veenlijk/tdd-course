using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO
{
    public class UserService
    {
        public IUserRepository userRepository { get; set; }

        public SEOPreparer preparer { get; set; }

        public void RegisterUser(string name, string profile)
        {
            List<string> searchTerms = preparer.ExtractSearchTerms(profile).ToList();
            userRepository.SaveNewUser(name.ToLower(), searchTerms);
        }
    }
}
