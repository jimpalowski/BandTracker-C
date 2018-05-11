using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandTracker.Models;

namespace BrandTracker.Models.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public ClientTests()
    {
     DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=verna_band_tracker_test;";
    }

    public void Dispose()
    {
      Client.ClearAll();
    }
    }
  }
