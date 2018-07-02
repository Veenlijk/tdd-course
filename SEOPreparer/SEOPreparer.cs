using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO
{
    public class SEOPreparer
    {
        private static string[] unnecessaryWords = new String[] { "this", "and", "the", "a", "an" };
        private static List<char> unnecesaryCharacters = new List<char> { '&', '<', '>', '_', '%' };
        private static string[] pluralFlags = new string[] { "s", "x" };

        public string[] ExtractSearchTerms(string searchString)
        {
            string[] searchTerms = RemoveUnnecessaryWords(searchString.ToLower());

            searchTerms = RemoveUnnecesaryCharacters(searchTerms);

            SingularizeSearchTerms(searchTerms);

            searchTerms = searchTerms.Distinct().ToArray();

            return searchTerms;
        }

        private static void SingularizeSearchTerms(string[] searchTerms)
        {
            for (int searchTermsIndex = 0; searchTermsIndex < searchTerms.Length; searchTermsIndex++)
            {
                searchTerms[searchTermsIndex] = SingularizeTerm(searchTerms[searchTermsIndex]);
            }
        }

        private static string SingularizeTerm(string searchTerm)
        {
            for (int pluralFlagsIndex = 0; pluralFlagsIndex < pluralFlags.Length; pluralFlagsIndex++)
            {
                if (searchTerm.EndsWith(pluralFlags[pluralFlagsIndex]))
                {
                    searchTerm = searchTerm.Remove(searchTerm.Length - pluralFlags[pluralFlagsIndex].Length);
                    break;
                }
            }

            return searchTerm;
        }

        private static string[] RemoveUnnecessaryWords(string searchString)
        {
            string[] searchTerms = searchString.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            searchTerms = searchTerms.Where(searchTerm => !unnecessaryWords.Contains(searchTerm)).ToArray();

            return searchTerms;
        }

        private static string[] RemoveUnnecesaryCharacters(string[] searchTerms)
        {
            for (int searchTermsIndex = 0; searchTermsIndex < searchTerms.Length; searchTermsIndex++)
            {
                searchTerms[searchTermsIndex] = new string(searchTerms[searchTermsIndex].ToCharArray().Where(c => !unnecesaryCharacters.Contains(c)).ToArray());
            }

            return searchTerms.Where(word => !word.Equals("")).ToArray(); ;
        }
    }
}
