using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eleven.Controllers;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using eleven.Service;
using eleven.Models.Entities;

namespace eleven.Tests.Controllers
{
    [TestClass]
    public class ProjectControllerTest
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
                type = "html",
            };
            mockDb.files.Add(f1);

            var f2 = new File
            {
                Id = 2,
                name = "FileToTest",
                type = "html",
                content = "Here is some fun text.", 
            };
            mockDb.files.Add(f1);

            _service = new ProjectService(mockDb);
        }

        
        [TestMethod]
        public void TestIndexErrorView()
        {
            //Arrange:
            var controller = new ProjectController();
            //Act:
            var result = controller.Index(0) as ViewResult;
            //Assert:
            Assert.AreEqual("Error", result.ViewName);
        }
        
    }
}
