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
            List<Regions>allRegion = Regions.GetAll();
            return View(allRegion);
        }
        [HttpGet("/Region/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string,object> model = new Dictionary<string,object>();
            Regions selectedRegion = Regions.Find(id);
            List <Info> regionInfo = selectedInfo.GetInfo();
            model.Add("region", selectedRegion);
            model.Add("info", regionInfo);
            return View(model);
        }
        [HttpGet("/Region/{region}/info")]
        public ActionResult Create(string region, string info)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Regions foundRegion = Regions.Find(region);
            Info newInfo = new Info(info);
            foundRegion.AddInfo(newInfo);
            List<Info> regionInfo = foundRegion.GetInfo();
            model.Add("info", regionInfo);
            model.Add("region", foundRegion);
            return View("Show", model);
        }
    }
}
