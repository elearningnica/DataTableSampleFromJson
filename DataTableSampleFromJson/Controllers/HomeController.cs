using DataTableSampleFromJson.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DataTableSampleFromJson.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private async Task<List<JsonPlaceholderModel>> getData()
        {
            using (var cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync("https://jsonplaceholder.typicode.com/todos"); //retrieve the data

                var contenido = await respuesta.Content.ReadAsStringAsync();

                var datos = JsonConvert.DeserializeObject<List<JsonPlaceholderModel>>(contenido);
                return datos;
            }
        }

        public async Task<ActionResult> loadData()
        {
            var data = await getData();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}