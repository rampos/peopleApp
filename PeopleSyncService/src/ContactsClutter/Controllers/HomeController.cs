﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ContactsClutter.Connectors;
using ContactsClutter.Models;

namespace ContactsClutter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<List<Contact>> Test(string token)
        {
            MicrosoftConnector msConnector = new MicrosoftConnector();
            return await msConnector.GetContactsAsync(token);
        }

        public async Task<int> Count()
        {
            MicrosoftConnector msConnector = new MicrosoftConnector();
            return await msConnector.GetContactCount();
        }
    }
}
