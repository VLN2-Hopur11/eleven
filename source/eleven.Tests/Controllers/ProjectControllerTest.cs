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
