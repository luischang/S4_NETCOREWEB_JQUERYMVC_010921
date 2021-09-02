﻿using Microsoft.AspNetCore.Mvc;
using S4_NETCOREWEB_JQUERYMVC.DatabaseFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S4_NETCOREWEB_JQUERYMVC.DatabaseFirst.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var customers = await CustomerRepo.GetCustomersAsync();
            return PartialView(customers);
        }




    }
}
