using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Brewery.Models;

namespace Brewery.Controllers
{
    public class RegionController : Controller
    {
        [HttpGet("/Region")]
        public ActionResult Region()
        {
            List<Region>allRegion = Region.GetAll();
            return View(allRegion);
        }
        [HttpGet("/Region/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string,object> model = new Dictionary<string,object>();
            Region selectedRegion = Region.Find(id);
            List <Item> regionInfo = selectedInfo.GetInfo();
            model.Add("region", selectedRegion);
            model.Add("info", regionInfo);
            return View(model);
        }
        [HttpGet("/Region/{region}/info")]
        public ActionResult Create(string region, string info)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Region foundRegion = Region.Find(region);
            Info newInfo = new Info(info);
            foundRegion.AddItem(newInfo);
            List<Item> regionInfo = foundRegion.GetInfo();
            model.Add("info", regionInfo);
            model.Add("region", foundRegion);
            return View("Show", model);
        }
    }
}
