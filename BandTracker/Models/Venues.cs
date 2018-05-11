using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BandTracker.Models;
using System;

namespace BandTracker.Models
{
  public class Venue
  {
    private string _name;
    private int _id;
    private List<Band> _bands;

    public Venue(string venueName, int venue_id = 0)
    {
      _name = venueName;
      _id = venue_id;
    }
    public override bool Equals(System.Object otherVenue)
    {
      if (!(otherVenue is Venue))
      {
        return false;
      }
      else
      {
        Venue newVenue = (Venue) otherVenue;
        bool idEquality = this.GetId() == newVenue.GetId();
        bool nameEquality = this.GetName() == newVenue.GetName();
        return (idEquality && nameEquality);
      }

    }

    public List<Band> GetBands()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT bands.* FROM venues
      JOIN bands_venues ON (venues.id = bands_venues.venue_id)
      JOIN bands ON (bands_venues.band_id = bands.id)
      WHERE venues.id = @VenueId;";

      MySqlParameter venueIdParameter = new MySqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = _id;
      cmd.Parameters.Add(venueIdParameter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Band> bands = new List<Band>{};

      while(rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandDescription = rdr.GetString(1);
        Band newBand = new Band(bandDescription, bandId);
        bands.Add(newBand);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return bands;
    }


    public void AddBand(Band newBand)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO bands_venues (venue_id, band_id) VALUES (@VenueId, @BandId);";

      MySqlParameter venue_id = new MySqlParameter();
      venue_id.ParameterName = "@VenueId";
      venue_id.Value = _id;
      cmd.Parameters.Add(venue_id);

      MySqlParameter band_id = new MySqlParameter();
      band_id.ParameterName = "@BandId";
      band_id.Value = newBand.GetId();
      cmd.Parameters.Add(band_id);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }

    public void SetId(int newId)
    {
      _id = newId;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public void SetList(List<Band> bands)
    {
      _bands = bands;
    }



    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO venues (name) VALUES (@name);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      // Code to declare, set, and add values to a categoryId SQL parameters has also been removed.

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Venue> GetAll()
    {
      List<Venue> allVenues = new List<Venue> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM venues;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        Venue newVenue = new Venue(venueName);
        newVenue.SetId(venueId);
        allVenues.Add(newVenue);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allVenues;
    }

    public static Venue Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM Venues WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int venueId = 0;
      string venueName = "";
      //string itemDueDate = "";
      // We remove the line setting a itemCategoryId value here.

      while(rdr.Read())
      {
        venueId = rdr.GetInt32(0);
        venueName = rdr.GetString(1);
        //    itemDueDate = rdr.GetString(2);
        // We no longer read the itemCategoryId here, either.
      }

      // Constructor below no longer includes a itemCategoryId parameter:
      Venue newVenue = new Venue(venueName, venueId);
      //  newCategory.SetDate(ItemDueDate);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return newVenue;
    }

    public static void Delete(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = new MySqlCommand("DELETE FROM venues WHERE id = @VenueId; DELETE FROM bands_venues WHERE venue_id = @VenueId;", conn);
      MySqlParameter venueIdParameter = new MySqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = id;

      cmd.Parameters.Add(venueIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM venues;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
