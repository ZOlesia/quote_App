using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quote_app.Models;
using DbConnection;

namespace quote_app.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            ViewBag.allQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY created_at desc");
            return View("About");
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult Add(string name, string quote)
        {
            DbConnector.Execute($"INSERT INTO quotes (user, quote, created_at, updated_at) VALUES ('{name}', '{quote}', NOW(), NOW());");
            return RedirectToAction("Quotes");
        }

        [HttpGet]
        [Route("skip")]
        public IActionResult Skip()
        {
            return RedirectToAction("Quotes");
        }
    }  
}
