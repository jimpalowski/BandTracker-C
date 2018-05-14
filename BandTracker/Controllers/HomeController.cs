using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using BandTracker.Models;

namespace BandTracker.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet("/success")]
    public ActionResult Success()
    {
      return View();
    }
    
  }
}
