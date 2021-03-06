using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brewery.Models;
using MySql.Data.MySqlClient;

namespace Brewery.Tests
{
    [TestClass]
    public class InfoTest : IDisposable
    {
        public void Dispose()
        {
            Info.ClearAll();
        }
        public InfoTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=brewery_test;";
        }

        [TestMethod]
        public void Equals_ReturnsTrueDescrption_Card()
        {
            Info brew1 = new Info("smog", "LA", 1990, "some Dude", "stout", "its good notes", "image.com");
            Info brew2 = new Info("smog", "LA", 1990, "some Dude", "stout", "its good notes", "image.com");

            Assert.AreEqual(brew1, brew2);
        }
        [TestMethod]
        public void Save_SavesBreweryToDatabase_BreweryList()
        {
            Info brewery = new Info("smog", "LA", 1990, "some Dude", "stout", "its good notes", "image.com");
            brewery.Save();

            List<Info> breweries = Info.GetAll();

            Assert.AreEqual(breweries.Count, 1);
        }

        [TestMethod]
        public void Save_AssingsIdToSavedBreweryInfo_Id()
        {
            Info brewery = new Info("smog", "LA", 1990, "some Dude", "stout", "its good notes", "image.com");
            brewery.Save();

            List<Info> breweries = Info.GetAll();

            Assert.AreEqual(breweries.Count, 1);

        }
    }
}