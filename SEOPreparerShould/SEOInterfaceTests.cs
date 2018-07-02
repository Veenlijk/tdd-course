using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEO.Tests.Stubs;
using System.Linq;

namespace SEO.Tests.SEOInterfaceTests
{
    /// <summary>
    /// Summary description for SEOInterfaceTests
    /// </summary>
    [TestClass]
    public class SEOInterfaceTests
    {
        SearchEngine searchEngine = new SearchEngine();

        [TestMethod]
        public void FindSingleUser()
        {
            UserStub user = new UserStub();
            UserRepositoryStub repo = new UserRepositoryStub();
            repo.users = new List<IUser>() { user };

            searchEngine.SetRepository(repo);
            List<IUser> users = searchEngine.Search("Francine C# Developer Delft");
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        public void FindThreeUsers()
        {
            UserStub user = new UserStub();
            UserRepositoryStub repo = new UserRepositoryStub();
            repo.users = new List<IUser>() { user, user, user };

            searchEngine.SetRepository(repo);
            List<IUser> users = searchEngine.Search("Delft");
            Assert.AreEqual(3, users.Count);
        }

        [TestMethod]
        public void FindUserByName()
        {
            UserStub user = new UserStub();
            UserRepositoryStub repo = new UserRepositoryStub();
            user.SetName("Bram");
            repo.users = new List<IUser>() { user };

            searchEngine.SetRepository(repo);
            List<IUser> users = searchEngine.Search("Bram");
            Assert.AreEqual(1, users.Count);
            Assert.AreEqual("Bram", users.FirstOrDefault().Name());
        }

        [TestMethod]
        public void FindUsersFromAmersfoort()
        {
            UserStub user = new UserStub();
            user.SetProfile(new List<string> { "Bram", "Junior Developer", "Amersfoort" });
            UserRepositoryStub repo = new UserRepositoryStub();
            repo.users = new List<IUser>() { user, user, user };

            searchEngine.SetRepository(repo);
            List<IUser> users = searchEngine.Search("Amersfoort");

            Assert.AreEqual(3, users.Count);
            foreach (UserStub currentUser in users)
            {
                Assert.IsTrue(currentUser.Profile().Contains("Amersfoort"));
            }
        }
    }
}
