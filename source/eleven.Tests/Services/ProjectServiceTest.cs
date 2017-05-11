using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eleven.Service;

namespace eleven.Tests.Services
{
    [TestClass]
    public class ProjectServiceTest
    {
        [TestMethod]
        public void TestUserExists()
        {
            // Arrange: const string user = "dabs";
            // Undirbua sjalfa profunina, bua til test gogn
            // var service = new UberService(); 
            var service = new ProjectService();

            // Act: var result = service.GetFriendsForUser(user);
            // adeins ein lina, keyra skipunina
            var result = service.userExists("rebekka13@ru.is");

            // Assert:  Assert.AreEqual(2, result.Count);
            // Er svarid thad sem vid vildum fa, urdu einhver ahrif
            Assert.IsFalse(result);
        }
    }
}
