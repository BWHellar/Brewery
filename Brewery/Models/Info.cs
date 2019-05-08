using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Brewery.Models
{
    // These are our strings and ints that we want to initiate as private.  The reason we do this is so that the core values cannot be altered and can only be accessed when needed.
    public class Info
    {
        // For each of these I am setting them as private then allowing them to be manipulated with following line by using the get and the return.

        private string _name;
        public string Name { get { return _name;} }

        private string _location;
        public string Location { get { return _location;} }

        private int _year;
        public int Year { get { return _year;} }

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

    // This compiles the variosu data that we need to put into the brewery.  We want to be able to call forth the entire brewery when we have it set from the database.
    public Info(string name, string location, int year, string founder, string beer, string notes, string logo, int id = 0)
    {
        _name = name;
        _location = location;
        _year = year;
        _founder = founder;
        _beer = beer;
        _notes = notes;
        _logo = logo;
        _id = id;
    
    }
    //  This is our save function and it allows us to put the data that we have input into our database as the set brewery.
    public void Save()
    {
        // Establishing the connection to make sure that it is going to our database.
        MySqlConnection conn = DB.Connection();
        // Open the connection
        conn.Open();
        // Declare the SQL command as the command to open the connection.
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        // These are the things we want to insert into the database.  THey should match the ordering stated above in order to call the right thing.
        cmd.CommandText = @"INSERT INTO brewery_info (name, location, year, founder, beer, notes, logo) 
        VALUES (@Name, @Location, @Year, @Founder, @Beer, @Notes, @Logo);";
        // Setting a new Parameter for each of the values we put into the current item of "this", which is the brewery we are writing about.
        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@Name";
        name.Value = this._name;

        MySqlParameter location = new MySqlParameter();
        location.ParameterName = "@Location";
        location.Value = this._location;

        MySqlParameter year = new MySqlParameter();
        year.ParameterName = "@Year";
        year.Value = this._year;

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
        //  This will actually add the item to the brewery we are working on.
        cmd.Parameters.Add(name);
        cmd.Parameters.Add(location);
        cmd.Parameters.Add(year);
        cmd.Parameters.Add(founder);
        cmd.Parameters.Add(beer);
        cmd.Parameters.Add(notes);
        cmd.Parameters.Add(logo);
        // NonQuery because we are not asking the server to return anything and only placing things within the database.
        cmd.ExecuteNonQuery();
        // Allows for an Id
        _id = (int) cmd.LastInsertedId;
        // Close the connection.
        conn.Close();
        //  If the connection is not available then this will dispose of the connection.
        if(conn != null)
        {
            conn.Dispose();
        }
    }
    
    public static List<Info> GetAll()
    {
        List<Info> allBrewerys = new List<Info>{};

        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM brewery_info;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

        while(rdr.Read())
        {
            string bName = rdr.GetString(0);
            string bLocation = rdr. GetString(1);
            int bYear = rdr.GetInt32(2);
            string bFounder = rdr.GetString(3);
            string bBeer = rdr.GetString(4);
            string bNotes = rdr.GetString(5);
            string bLogo = rdr.GetString(6);
            int bId = rdr.GetInt32(7);

            Info brewery = new Info(bName, bLocation, bYear, bFounder, bBeer, bNotes, bLogo, bId);
            allBrewerys.Add(brewery);
        }

        conn.Close();
        if(conn != null)
        {
            conn.Dispose();
        }
        return allBrewerys;
    }

    public override bool Equals(object obj)
    {
        if(!(obj is Info))
        {
            return false;
        }
        else 
        {
            Info brewery =(Info) obj;
            return this.Id == brewery.Id && this.Name == brewery.Name;
        }
    }

    public static void ClearAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM brewery_info;";
        cmd.ExecuteNonQuery();

        conn.Close();
        if(conn != null)
        {
            conn.Dispose();
        }
    }
    }
}