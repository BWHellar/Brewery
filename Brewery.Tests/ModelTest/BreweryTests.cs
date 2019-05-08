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
            BreweryInfo.ClearAll();
        }
        public InfoTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=brewery_test;";
        }

        // [TestMethod]
        // public void Save_SavesBreweryToDatabase_BreweryList()
        // {
        //     BreweryInfo brewery = new BreweryInfo("smog", "LA", 12/03/19, "some Dude", "stout", "its good notes", "image.com");
        //     brewery.Save();

        //     List<BreweryInfo> brewerys = BreweryInfo.GetAll();

        //     Assert.AreEqual(brewerys.Count, 1);
        // }

        [TestMethod]
        public void Save_AssingsIdToSavedBreweryInfo_Id()
        {
            BreweryInfo brewery = new BreweryInfo("smog", "LA", 12/03/19, "some Dude", "stout", "its good notes", "image.com");
            brewery.Save();

            List<BreweryInfo> brewerys = BreweryInfo.GetAll();

            Assert.AreEqual(brewerys.Count, 1);

        }
    }
}