using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace salesApp.Controllers
{
    [Route("/")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        [HttpGet("/counter")]
        public IActionResult GetCounter()
        {
            Random rand = new Random(); 
            
            var metric = Metrics.CreateCounter("sales_counter_api",
            "Counter about sales API Data", new CounterConfiguration
                {
                    LabelNames = new[] {"method"}
                });

            if (rand.Next(1, 101) <= 60)
            {
                metric.WithLabels(HttpContext.Request.Method).Inc();
            }

            return Ok();
        }
        
        [HttpGet("/gauge")]
        public IActionResult GetGauge()
        {
            Random rand = new Random(); 
            
            var metric = Metrics.CreateGauge("sales_gauge_api",
                "Gauge Sample", new GaugeConfiguration
                {
                    LabelNames = new[] {"method"}
                });

            if (rand.Next(1, 101) <= 51)
            {
                metric.WithLabels(HttpContext.Request.Method).Inc();
            }
            else
            {
                metric.WithLabels(HttpContext.Request.Method).Dec();
            }

            return Ok();
        }
        
        [HttpGet("/histogram")]
        public IActionResult GetHistogram()
        {
            Random rand = new Random(); 
            
            var stopWatch = Stopwatch.StartNew();
            Thread.Sleep(rand.Next(1, 50));
            stopWatch.Stop();

            var histogram =
                Metrics
                    .CreateHistogram(
                        "sales_histogram_api",
                        "Histogram Sample",
                        "method");

            histogram
                .WithLabels(HttpContext.Request.Method)
                .Observe(stopWatch.Elapsed.TotalSeconds);

            return Ok();
        }
    }
}