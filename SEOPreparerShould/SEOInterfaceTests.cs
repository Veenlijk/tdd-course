using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEO.Tests.Stubs;
using System.Linq;
using Moq;

namespace SEO.Tests.SEOInterfaceTests
{
    [TestClass]
    public class SEOInterfaceTests
    {
        Mock<IUser> user = new Mock<IUser>();
        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
        

        SearchEngine searchEngine = new SearchEngine();

        [TestMethod]
        public void FindSingleUser()
        {
            userRepository.Setup(repo => repo.FindBy("developer")).Returns(new List<IUser>() { user.Object });
            userRepository.Setup(repo => repo.FindBy("c")).Returns(new List<IUser>() { user.Object });

            searchEngine.SetRepository(userRepository.Object);

            List<IUser> users = searchEngine.Search("developer");
            List<IUser> users2 = searchEngine.Search("c");

            userRepository.VerifyAll();
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
            // stub
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
        [TestMethod]
        public void SaveNewUser()
        {
            /* "francine", "helpdesk hrm" => User("francine", profile: "hrm", "helpdesk")
             * "bob", "developer" => User("bob", profile: "developer")
             * "chris", "" => Exception ()  //Not a User("chris", profile "")
             *  "", "c# developer" => Exception() 
             *  "bob", "developer" => Exception() // allready exists
             * */

            userRepository.Setup(repository => repository.SaveNewUser("bob", new List<string>() { "developer" }));

            UserService userService = new UserService();
            userService.userRepository = userRepository.Object;

            userService.RegisterUser("bob", "developer");
            
            userRepository.VerifyAll();
        }

        //[TestMethod]
        //public void SaveNamelessUser()
        //{

        //}
    }
}
