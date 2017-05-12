using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eleven.Service;
using eleven.Models.Entities;
using eleven.Tests;

namespace eleven.Tests.Services
{
    [TestClass]
    public class ProjectServiceTest
    {
        private ProjectService _service;

        [TestInitialize]
        public void Initialize()
        {
            var mockDb = new MockDatabase();

            //The data that are in the mock database
            var p1 = new Project
            {
                Id = 1,
                name = "ProjectTesting",
                author = "Rebekka",
            };
            mockDb.projects.Add(p1);

            var p2 = new Project
            {
                Id = 2,
                name = "ProjectTwoBaby",
                author = "Einar",
            };
            mockDb.projects.Add(p2);

            _service = new ProjectService(mockDb);
        }

        [TestMethod]
        public void TestchangeProjectName()
        {
            // Arrange: const string user = "dabs";
            string newName = "NewProjectName";
            // Undirbua sjalfa profunina, bua til test gogn
          
            // Act: var result = service.GetFriendsForUser(user);
            // adeins ein lina, keyra skipunina
            var result = _service.changeProjectName(1, newName);

            // Assert:  Assert.AreEqual(2, result.Count);
            // Er svarid thad sem vid vildum fa, urdu einhver ahrif
            Assert.IsTrue(result);
        }
        /*
        [TestMethod]
        public void TestchangeProjectName()
        {
            // Arrange: making the test data
            string newName = "MeetStreet";
            // Undirbua sjalfa profunina, bua til test gogn

            // Act: var result = service.GetFriendsForUser(user);
            // adeins ein lina, keyra skipunina
            var result = _service.changeProjectName(2, newName);

            // Assert:  Assert.AreEqual(2, result.Count);
            // Er svarid thad sem vid vildum fa, urdu einhver ahrif
            Assert.Equals(, newName);
        }*/

        [TestMethod]
        public void TestchangeProjectNameToEmpty()
        {
            // Arrange: const string user = "dabs";
            string newName = "";
            // Undirbua sjalfa profunina, bua til test gogn

            // Act: var result = service.GetFriendsForUser(user);
            // adeins ein lina, keyra skipunina
            var result = _service.changeProjectName(1, newName);

            // Assert:  Assert.AreEqual(2, result.Count);
            // Er svarid thad sem vid vildum fa, urdu einhver ahrif
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRemoveProject()
        {
            // Arrange: const string user = "dabs";
            //string newName = "";
            // Undirbua sjalfa profunina, bua til test gogn

            // Act: var result = service.GetFriendsForUser(user);
            // adeins ein lina, keyra skipunina
            var result = _service.removePoject(2);

            // Assert:  Assert.AreEqual(2, result.Count);
            // Er svarid thad sem vid vildum fa, urdu einhver ahrif
            Assert.IsTrue(result);
        }
    }
}
