﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using Globomantics.Filters;
using Globomantics.Conventions;

namespace Globomantics.Controllers
{
    [ControllerVersion(Version = 1)]
    [Route("api/Rates")]
    [RateExceptionFilter]
    public class RatesController : Controller
    {
        private IRateService rateService;

        public RatesController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        [HttpGet]
        [Route("mortgage")]
        public IActionResult GetMortgageRates()
        {
            return Ok(rateService.GetMortgageRates());
        }


        [HttpGet]
        [Route("credit")]
        public IActionResult GetCreditCardRates()
        {
            return Ok(rateService.GetCreditCardRates());
        }


        [HttpGet]
        [Route("cd")]
        public IActionResult GetCDRates()
        {
            return Ok(rateService.GetCDRates());
        }
    }
}
