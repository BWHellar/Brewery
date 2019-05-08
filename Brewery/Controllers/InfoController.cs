using Microsoft.AspNetCore.Mvc;
using Brewery.Models;
using System.Collections.Generic;

namespace Brewery.Controllers
{
    public class BreweryController : Controller
    {
        [HttpGet("/region/create")]
        public ActionResult Create(string name, string)
    }
}