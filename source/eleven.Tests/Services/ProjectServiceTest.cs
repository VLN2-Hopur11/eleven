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

            var f1 = new File
            {
                Id = 1,
                name = "FileForTest",
                fileType = "html",
            };
            mockDb.files.Add(f1);

            var f2 = new File
            {
                Id = 2,
                name = "FileToTest",
                fileType = "html",
            };
            mockDb.files.Add(f1);

            _service = new ProjectService(mockDb);
        }

        [TestMethod]
        public void TestchangeProjectName()
        {
            // Arrange: 
            string newName = "NewProjectName";

            // Act:
            var result = _service.changeProjectName(1, newName);

            // Assert: 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestchangeProjectNameFalse()
        {
            // Arrange: making the test data
            string newName = "MeetStreet";

            // Act: Only one line calling the function
            var result = _service.changeProjectName(0, newName);

            // Assert:  
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRemoveProject()
        {
            // Arrange: 
            // Act: 
            var result = _service.removePoject(2);

            // Assert:  
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestRemoveProjectFalse()
        {
            // Arrange: 
            int projectId = 0;
            // Act: 
            var result = _service.removePoject(projectId);

            // Assert: 
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRemoveProjectOutOfRange()
        {
            // Arrange:
            int projectIdOutOfRange = 10; 
            // Act: 
            var result = _service.removePoject(projectIdOutOfRange);

            // Assert:
            Assert.IsFalse(result);
        }
    }
}
