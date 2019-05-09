using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Brewery.Models
{
    public class Regions
    {
        private static List<Info> _instances = new List<Info> {};
        private string _name;
        private List<Info> _info;
    
    public static Region(string regionName)
    {
        _name = regionName;
        _instances.Add(this);
        _brewery = new List<Info> {};
    }
    public string GetName()
    {
        return _name;
    }
    public static List<Info> GetAll()
    {
        return _instances;
    }
    public static Region Find(string region)
    {
        return _instances[searchId-1];
    }
    public List<Info> GetInfo()
    {
        return _info;
    }
    }
}
