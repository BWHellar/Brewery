using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Brewery.Models
{
    // These are our strings and ints that we want to initiate as private.  The reason we do this is so that the core values cannot be altered and can only be accessed when needed.
    public class Brewery
    {
        // For each of these I am setting them as private then allowing them to be manipulated with following line by using the get and the return.

        private string _name;
        public string Name { get { return _name;} }

        private string _location;
        public string Location { get { return _location;} }

        private int _date;
        public int Date { get { return _date;} }

        private string _founder;
        public string Founder { get { return _founder;} }

        private string _beer;
        public string Beer { get { return _beer;} }

        private string _notes;
        public string Notes { get { return _notes;} }

        private string _logo;
        public string Logo { get { return _logo;} }

        private int _id;
        public int Id { get { return _id;} }

    // This compiles the variosu data that we need to put into the brewery.
    public Brewery(string name, string location, int date, string founder, string beer, string notes, string logo, int id = 0)
    {
        _name = name;
        _location = location;
        _date = date;
        _founder = founder;
        _beer = beer;
        _notes = notes;
        _logo = logo;
        _id = id;
    
    }
    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO brewery (name, location, date, founder, beer, notes, logo) 
        VALUES (@Location, @Date, @Founder, @Brewery, @Notes, @Logo);";

        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@Name";
        name.Value = this._name;

        MySqlParameter location = new MySqlParameter();
        location.ParameterName = "@Location";
        location.Value = this._location;

        MySqlParameter date = new MySqlParameter();
        date.ParameterName = "@Date";
        date.Value = this._date;

        MySqlParameter founder = new MySqlParameter();
        founder.ParameterName = "@Founder";
        founder.Value = this._founder;

        MySqlParameter beer = new MySqlParameter();
        beer.ParameterName = "@Beer";
        beer.Value = this._beer;

        MySqlParameter notes = new MySqlParameter();
        notes.ParameterName = "@Notes";
        notes.Value = this._notes;

        MySqlParameter logo = new MySqlParameter();
        logo.ParameterName = "@Logo";
        logo.Value = this._logo;
        
        cmd.Parameters.Add(name);
        cmd.Parameters.Add(location);
        cmd.Parameters.Add(date);
        cmd.Parameters.Add(founder);
        cmd.Parameters.Add(beer);
        cmd.Parameters.Add(notes);
        cmd.Parameters.Add(logo);

        cmd.ExecuteNonQuery();

        _id = (int) cmd.LastInsertedId;

        conn.Close();
        if(conn != null)
        {
            conn.Dispose();
        }
    }

    public static List<Brewery> GetAll()
    {
        List<Brewery> allBrewery = new List<Brewery>{};

        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd CommandText = @"SELECT * FROM brewery;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

        while(rdr.Read())
        {
            int bId = rdr.GetInt11(0);
            string bName = rdr.GetString(1);
            string bLocation = rdr. GetString(2);
            int bDate 
        }
    }
    }
}