using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace salesApp.Controllers
{
    [Route("/")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        [HttpGet("/counter")]
        public IActionResult Get()
        {
            var metric = Metrics.CreateCounter("counter_api",
            "Data about sales API Data", new CounterConfiguration
            {
                LabelNames = new[] {"method"}
            });

            metric.WithLabels(HttpContext.Request.Method).Inc();

            return Ok();
        }
    }
}