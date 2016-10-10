using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Yoox.Commerce.Web.Models;

namespace Yoox.Commerce.Web.Controllers
{
    public class ClientiController : Controller
    {
        // GET: Clienti
        public ActionResult Crea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crea(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                using(var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiUrl"]);
                    var rs = cl.PostAsJsonAsync("api/clienti", cliente);

                    rs.Wait();

                    if (rs.Result.IsSuccessStatusCode)
                    {
                        var url = rs.Result.Headers.GetValues("Location").FirstOrDefault();

                        return RedirectToAction("Dettaglio", new { url = url });
                    }
                }
            }

            return View(cliente);
        }

        public ActionResult Dettaglio(string url)
        {
            using(var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiUrl"]);
                var rs = cl.GetAsync(url);

                rs.Wait();

                if(rs.Result.IsSuccessStatusCode)
                {
                    var cliente = rs.Result.Content.ReadAsAsync<Cliente>();
                    cliente.Wait();

                    return View(cliente.Result);
                }
            }

            throw new ApplicationException();
        }
    }
}