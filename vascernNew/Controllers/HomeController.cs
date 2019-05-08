using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using vascernNew.Models;


namespace vascernNew.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet, ActionName("GetEventVenuesList")]
        public JsonResult GetEventVenuesList(string SearchText, string ApiKey)
        {
            string placeApiUrl = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input={0}&key={1}";

            try
            {
                placeApiUrl = placeApiUrl.Replace("{0}", SearchText);
                placeApiUrl = placeApiUrl.Replace("{1}", ApiKey);

                var result = new System.Net.WebClient().DownloadString(placeApiUrl);
                var Jsonobject = JsonConvert.DeserializeObject<RootObject>(result);

                List<Prediction> list = Jsonobject.predictions;

                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet, ActionName("GetEventVenuesListFertilab")]
        public JsonResult GetEventVenuesListFertilab(string SearchText, string ApiKey)
        {
            string placeApiUrl = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input={0}&key={1}&language=it";

            try
            {
                placeApiUrl = placeApiUrl.Replace("{0}", SearchText);
                placeApiUrl = placeApiUrl.Replace("{1}", ApiKey);

                var result = new System.Net.WebClient().DownloadString(placeApiUrl);
                var Jsonobject = JsonConvert.DeserializeObject<RootObject>(result);

                List<Prediction> list = Jsonobject.predictions;

                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet, ActionName("GetGeocode")]
        public JsonResult GetGeocode(string Address, string ApiKey)
        {
            string placeApiUrl = "https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}";

            try
            {
                placeApiUrl = placeApiUrl.Replace("{0}", Address);
                placeApiUrl = placeApiUrl.Replace("{1}", ApiKey);

                var result = new System.Net.WebClient().DownloadString(placeApiUrl);
                var Jsonobject = JsonConvert.DeserializeObject<object>(result);

                return Json(Jsonobject);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
