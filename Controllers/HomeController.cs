using ApplicationInsightWebapps.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;
using System.Text;
using System.Xml.Linq;

namespace ApplicationInsightWebapps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TelemetryClient _telemetryClient;
        private static List<string> _data;


        public HomeController(ILogger<HomeController> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            _telemetryClient = telemetryClient;
            //TelemetryClient telemetryClient = new TelemetryClient();

        }

        public IActionResult Index()
        {
        
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SubmitForm(string ddpErrorType, int performancecount, string sourcetype, string CustomErrorMeessage)
        {
          

            while (performancecount != 0)
            {
                
                _telemetryClient.TrackTrace(CustomErrorMeessage, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Error);
                performancecount--;
            }
                return RedirectToAction("Thanksmessage");
        }

        public IActionResult Thanksmessage()
        {
            return View();
        }
        public IActionResult Warning()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> WarningForm(string ddpErrorType, int performancecount, string sourcetype, string CustomErrorMeessage)
        {
            while (performancecount != 0)
            {
                _telemetryClient.TrackTrace(CustomErrorMeessage, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Warning);
                performancecount--;
            }
            return RedirectToAction("Thanksmessage");
        }

        public IActionResult Critical()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriticalForm(string ddpErrorType, int performancecount, string sourcetype, string CustomErrorMeessage)
        {
            while (performancecount != 0)
            {
                _telemetryClient.TrackTrace(CustomErrorMeessage, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Critical);
                performancecount--;
            }
            return RedirectToAction("Thanksmessage");
        }


        public IActionResult Performance()
        {

            return View();
        }

        private static string GenerateLargeData()
        {
            var data = new List<string>();
            string str = "sales";
            string dummy = "";

            // Generate a large dataset
            for (int i = 0; i < 1000; i++)
            {
                str = str + " " + dummy;
                //data.Add($"Data_{i}");
            }

            return str;
        }

        private static string SlowOperation()
        {
            // Simulate a slow operation that iterates over a large dataset
            var result = string.Empty;

            foreach (var item in _data)
            {
                // Simulate some processing time
                //Thread.Sleep(1);

                // Concatenate the data
                result += item;
            }

            return result;
        }
        [HttpPost]
        public async Task<IActionResult> PerformanceForm(string ddpErrorType, int performancecount, string sourcetype, string CustomErrorMeessage)
        {
            try
            {
                Thread.Sleep(10000); // Delay for 5 seconds
                
                //Create the Performane Issue :Ends
                while (performancecount != 0)
                {
                    _telemetryClient.TrackTrace(CustomErrorMeessage, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Critical);
                    //Create the Performance Issue:Start
                    var data = GenerateLargeData();

                    // Measure the execution time
                    var stopwatch = Stopwatch.StartNew();

                    // Perform a slow operation
                    //var result = SlowOperation();
                    stopwatch.Stop();

                    performancecount--;
                }
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("Thanksmessage");
        }


        public IActionResult Trace()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TraceForm(string ddpErrorType, int performancecount, string sourcetype, string CustomErrorMeessage)
        {
            while (performancecount != 0)
            {
                _telemetryClient.TrackTrace(CustomErrorMeessage, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Verbose);
                performancecount--;
            }
            return RedirectToAction("Thanksmessage");
        }
        public IActionResult Information()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InformationForm(string ddpErrorType, int performancecount, string sourcetype, string CustomErrorMeessage)
        {
            while (performancecount != 0)
            {
                _telemetryClient.TrackTrace(CustomErrorMeessage, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Information);
                performancecount--;
            }
            return RedirectToAction("Thanksmessage");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}