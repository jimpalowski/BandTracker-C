using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using BandTracker.Models;
using System;

namespace BandTracker.Controllers
{
  public class BandsController : Controller
  {
    [HttpGet("/bands")]
    public ActionResult Index()
    {
      List<Band> allBands = Band.GetAll();
      return View(allBands);
    }
    [HttpGet("/bands/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/bands")]
    public ActionResult Create()
    {
      Band newBand = new Band(Request.Form["band-description"]);
      newBand.Save();
      return RedirectToAction("Success", "Home");
    }

    [HttpGet("/venues/{venueId}/bands/new")]
    public ActionResult CreateForm(int venueId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Venue venue = Venue.Find(venueId);
      return View(venue);
    }
    [HttpGet("/bands/{id}")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Band selectedBand = Band.Find(id);
      List<Venue> bandVenues = selectedBand.GetVenues();
      List<Venue> allVenues = Venue.GetAll();
      model.Add("selectedBand", selectedBand);
      model.Add("bandVenues", bandVenues);
      model.Add("allVenues", allVenues);
      return View(model);
    }
    [HttpGet("/venues/{venueId}/bands/{bandId}")]
    public ActionResult Details(int venueId, int bandId)
    {
      Band band = Band.Find(bandId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Venue venue = Venue.Find(venueId);
      model.Add("band", band);
      model.Add("venue", venue);
      return View(band);
    }
    [HttpPost("/bands/{bandId}/venues/new")]
    public ActionResult AddVenue(int bandId)
    {
      Band band = Band.Find(bandId);
      Venue venue = Venue.Find(Int32.Parse(Request.Form["venue-id"]));
      band.AddVenue(venue);
      return RedirectToAction("Details",  new { id = bandId });
    }

    [HttpGet("/bands/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Band thisBand = Band.Find(id);
      return View(thisBand);
    }
    [HttpPost("/bands/{id}/update")]
    public ActionResult Update(int id)
    {
      Band thisBand = Band.Find(id);
      thisBand.Edit(Request.Form["newname"]);
      return RedirectToAction("Details");
    }
    
  }
}
