// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using BandTracker.Controllers;
// using BandTracker.Models;
// using System;
//
// namespace BandTracker.Tests
// {
//   [TestClass]
//   public class HomeControllerTest
//   {
//     [TestMethod]
//     public void Index_ReturnsCorrectView_True()
//     {
//       //Arrange
//       HomeController controller = new HomeController();
//
//       //Act
//       ActionResult indexView = controller.Index();
//
//       //Assert
//       Assert.IsInstanceOfType(indexView, typeof(ViewResult));
//     }
//
//     [TestMethod]
//     public void Index_HasCorrectModelType_BandList()
//     {
//       //Arrange
//       ViewResult indexView = new HomeController().Index() as ViewResult;
//
//       //Act
//       var result = indexView.ViewData.Model;
//
//       //Assert
//       Assert.IsTrue(result.GetType() == typeof(List<Band>));
//       Assert.IsInstanceOfType(result, typeof(List<Band>));
//     }
//   }
// }
