using System;
using System.Collections.Generic;
using System.Text;

namespace SEO.Tests.Stubs
{
    public class UserStub : IUser
    {
        private string name;
        public string Name()
        {
            if (name != null)
            {
                return this.name;
            }
            else
            {
                return "";
            }
        }

        private List<string> profile;

        public List<string> Profile()
        {
            if (profile != null)
            {
                return this.profile;
            }
            else
            {
                return new List<string>();
            }
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetProfile(List<string> profile)
        {
            this.profile = profile;
        }
    }
}
