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
          DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=verna_band_tracker_test;";
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


      // [TestMethod]
      // public void Band_Save_SavesBandToDatabase()
      // {
      //   Band testBand = new Band("The Script");
      //   testBand.Save();
      //
      //   Band savedBand = Band.GetAll()[0];
      //
      //   Assert.Equal(testBand, savedBand);
      // }

      // [Fact]
      // public void Band_Save_SaveAssignsIdToObject()
      // {
      //   Band testBand = new Band("The Soft Pack");
      //   testBand.Save();
      //
      //   Band savedBand = Band.GetAll()[0];
      //
      //   int result = savedBand.GetId();
      //   int testId = testBand.GetId();
      //
      //   Assert.Equal(result, testId);
      // }
      //
      // [Fact]
      // public void Band_Find_FindBandInDatabase()
      // {
      //   Band testBand = new Band("The Soft Pack");
      //   testBand.Save();
      //
      //   Band foundBand = Band.Find(testBand.GetId());
      //
      //   Assert.Equal(testBand, foundBand);
      // }
      //
      // [Fact]
      // public void Band_AddVenue_AddAssociationThatBandPlayedVenue()
      // {
      //   Band testBand = new Band("The Roseland");
      //   testBand.Save();
      //
      //   Venue testVenueZero = new Venue("Roseland");
      //   testVenueZero.Save();
      //
      //   Venue testVenueOne = new Venue("Crystal Ballroom");
      //   testVenueOne.Save();
      //
      //   testBand.AddVenue(testVenueZero);
      //   testBand.AddVenue(testVenueOne);
      //   List<Venue> savedVenues = testBand.GetVenues();
      //   List<Venue> testList = new List<Venue> {testVenueZero, testVenueOne};
      //
      //   Assert.Equal(testList, savedVenues);
      // }
      //
      // [Fact]
      // public void Band_GetVenues_AddAssociationThatBandPlayedVenue()
      // {
      //   Band testBand = new Band("The Roseland");
      //   testBand.Save();
      //
      //   Venue testVenueZero = new Venue("Roseland");
      //   testVenueZero.Save();
      //
      //   Venue testVenueOne = new Venue("Crystal Ballroom");
      //   testVenueOne.Save();
      //
      //   testBand.AddVenue(testVenueZero);
      //   List<Venue> savedVenues = testBand.GetVenues();
      //   List<Venue> testList = new List<Venue> {testVenueZero};
      //
      //   Assert.Equal(testList, savedVenues);
      // }
      //
      // public void Dispose()
      // {
      //   Band.DeleteAll();
      // }
    }
}
