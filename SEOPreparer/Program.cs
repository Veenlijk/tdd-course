using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO
{
    class Program
    {
        static void Main(string[] args)
        {
            SEOPreparer preparer = new SEOPreparer();

            String[] query = preparer.ExtractSearchTerms("wat is een bgs");

        }
    }
}
