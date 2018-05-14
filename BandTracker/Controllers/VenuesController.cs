using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using BandTracker.Models;

namespace BandTracker.Controllers
{
  public class VenuesController : Controller
  {
    [HttpGet("/venues")]
    public ActionResult Index()
    {
      List<Venue> allVenues = Venue.GetAll();
      return View(allVenues);
    }
    [HttpGet("/venues/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/venues")]
    public ActionResult Create()
    {
      Venue newVenue = new Venue(Request.Form["venue-name"]);
      newVenue.Save();
      return RedirectToAction("Success", "Home");
    }
    [HttpGet("/venues/{id}")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Venue selectedVenue = Venue.Find(id);
      List<Band> venueBands = selectedVenue.GetBands();
      List<Band> allBands = Band.GetAll();
      model.Add("selectedVenue", selectedVenue);
      model.Add("venueBands", venueBands);
      model.Add("allBands", allBands);
      return View(model);
    }
    [HttpPost("/venues/{venueId}/bands/new")]
    public ActionResult AddBand(int venueId)
    {
      Venue venue = Venue.Find(venueId);
      Band band = Band.Find(Int32.Parse(Request.Form["band-id"]));
      venue.AddBand(band);
      return RedirectToAction("Details",  new { id = venueId });
    }
    [HttpPost("/venues/{id}/delete")]
     public ActionResult DeleteVenue(int id)
     {
     Venue.Delete(id);
     return RedirectToAction("Details", "Venues", new { id = id });
  }
  }
}
