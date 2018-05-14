using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using BandTracker.Models;
using System;

namespace BandTracker.Tests
{

[TestClass]
public class VenueTests : IDisposable
{
  public VenueTests()
  {
    DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=verna_band_tracker_test;";
  }
  public void Dispose()
  {
    Venue.DeleteAll();

  }
  [TestMethod]
  public void GetAll_DbStartsEmpty_0()
  {
    //Arrange
    //Act
    int result = Venue.GetAll().Count;

    //Assert
    Assert.AreEqual(0, result);
  }
  [TestMethod]
  public void Venue_Save_SavesVenueToDatabase()
  {
    //Arrange
    Venue testVenue = new Venue("Moore Theater");
    testVenue.Save();
    //Act
    Venue savedVenue = Venue.GetAll()[0];
    //Assert
    Assert.AreEqual(testVenue, savedVenue);
  }
}
}
