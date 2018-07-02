using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO
{
    public class SearchEngine
    {
        public IUserRepository repository { get; private set; }

        public SearchEngine()
        {

        }

        public void SetRepository(IUserRepository repository)
        {
            this.repository = repository;
        }

        public List<IUser> Search(string input)
        {
            return this.repository.FindBy(input);
        }

    }
}
