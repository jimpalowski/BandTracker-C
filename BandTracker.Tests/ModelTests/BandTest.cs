using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using BandTracker.Models;
using System;

namespace BandTracker.Tests
{

  [TestClass]
  public class BandTests : IDisposable
  {
    public BandTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=verna_band_tracker_test;";
    }
    public void Dispose()
    {
      Band.DeleteAll();

    }
    [TestMethod]
    public void GetAll_DbStartsEmpty_0()
    {
      //Arrange
      //Act
      int result = Band.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void Find_FindsBandInDatabase_Band()
    {
      //Arrange
      Band testBand = new Band("The Script");

      testBand.Save();

      //Act
      Band foundBand = Band.Find(testBand.GetId());

      //Assert
      Assert.AreEqual(testBand, foundBand);
    }
    [TestMethod]
    public void Band_Save_SavesBandToDatabase()
    {
      //Arrange
      Band testBand = new Band("The Script");
      testBand.Save();
      //Act
      Band savedBand = Band.GetAll()[0];
      //Assert
      Assert.AreEqual(testBand, savedBand);
    }
    [TestMethod]
    public void Band_AddVenue()
    {
      //Arrange
      Band testBand = new Band("The Beatles");
      testBand.Save();

      //Act
      Venue testVenue = new Venue("Moore Theater");
      testVenue.Save();

      Venue testVenueOne = new Venue("The Paramaount");
      testVenueOne.Save();

      testBand.AddVenue(testVenue);
      testBand.AddVenue(testVenueOne);
      List<Venue> savedVenues = testBand.GetVenues();
      List<Venue> testList = new List<Venue> {testVenue, testVenueOne};

      //Assert
      CollectionAssert.AreEqual(testList, savedVenues);
    }
    // [TestMethod]
    // public void Update_UpdateBandInDatabase()
    // {
    //   Band testBand = new Band("The Beatles");
    //   testBand.Save();
    //
    //   string newName = "The Script";
    //
    //
    //   Band newBand = new Band(newName);
    //   testBand.Update(newName);
    //
    //   Assert.AreEqual(newBand.Name, testBand.Name);

    }
  }
