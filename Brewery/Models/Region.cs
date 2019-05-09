using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Brewery.Models
{
    public class Regions
    {
        private string _region;
        public string Region{ get { return _region; } }
    
    public Regions (string region)
    {
        _region=region;
    }
    public void SaveRegion()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO brewery_info (region) Values (@Region);";
        MySqlParameter region = new MySqlParameter();
        region.ParameterName = "@Region";
        region.Value = this._region;
        cmd.Parameters.Add(region);

        conn.Close();
        if(conn !=null)
        {
            conn.Dispose();
        }
    }
    }
}
