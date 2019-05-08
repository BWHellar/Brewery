using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brewery.Models;
using MySql.Data.MySqlClient;

namespace BreweryInfo.Tests
{
    [TestClass]
    public class InfoTest : IDisposable
    {
        public void Dispose()
        {
            .ClearAll();
        }
        public InfoTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=brewery_test;";
        }

        [TestMethod]
        public void Save_SavesBreweryToDatabase_BreweryList()
        {
            Brewery brew = new Brewery("smog", "LA", "12/03/19", "some Dude", "stout", "its good notes", "image.com");
            brew.Save();
            List<Brewery> brews = Brewery.GetAll();
            Assert.AreEual(brews.Count, 1);
        }
    }
}