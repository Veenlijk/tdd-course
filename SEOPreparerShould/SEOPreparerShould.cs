using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEO;

namespace SEO.Tests.SEOPreparerShould
{
    [TestClass]
    public class SEOPreparerShould
    {
        private SEOPreparer seoPreparer = new SEOPreparer();

        private void ShouldParseInto(string queryString, params String[] expected)
        {
            // Act
            String[] result = seoPreparer.ExtractSearchTerms(queryString);
            for (int i = 0; i < result.Count(); i++)
            {
                // Assert
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("SEOTests"), TestMethod]
        public void ReturnEmptyTerms()
        {
            ShouldParseInto("", "");
        }

        [TestCategory("SEOTests"), TestMethod]
        public void ToLowerCase()
        {
            ShouldParseInto("TABLE", "table");
        }

        [TestCategory("SEOTests"), TestMethod]
        public void RemoveWhiteSpace()
        {
            ShouldParseInto("chris     eats", "chri", "eat");
        }

        [TestCategory("SEOTests"), TestMethod]
        public void RemoveUnnecessaryWords()
        {
            ShouldParseInto("Marc likes this and this", "marc", "like");
        }

        [TestCategory("SEOTests"), TestMethod]
        public void RemoveDuplicates()
        {
            ShouldParseInto("so many many bugs", "so", "many", "bug");
        }

        [TestCategory("SEOTests"), TestMethod]
        public void Singularize()
        {
            ShouldParseInto("sex", "se");
            ShouldParseInto("tables footers headerx", "table", "footer", "header");
            ShouldParseInto("table footer xHEADERS XCODEX", "table", "footer", "xheader", "xcode");
        }

        [TestCategory("SEOTests"), TestMethod]
        public void RemoveDuplicatesAfterSingularize()
        {
            ShouldParseInto("tables table", "table");
        }

        [TestCategory("SEOTests"), TestMethod]
        public void RemoveSpecialCharacters()
        {
            ShouldParseInto("tables & &table", "table");
        }
    }
}
