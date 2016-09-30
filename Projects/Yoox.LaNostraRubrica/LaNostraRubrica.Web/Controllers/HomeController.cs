using LaNostraRubrica.DAL;
using LaNostraRubrica.DAL.ViewModels;
using LaNostraRubrica.Web.Models;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaNostraRubrica.Web.Controllers
{
    public class HomeController : Controller
    {
        static HomeController()
        {
            //TinyMapper.Bind<PersonaGet, HomeIndexPersonaVM>(config => 
            //{
            //    config.Bind(s => s.Nome + " " + s.Cognome, t => t.NomeCompleto);
            //});
        }

        // GET: Home
        public ActionResult Index(int? gruppoId = null, string Query = null)
        {
            var model = new HomeIndexVM();
            model.Gruppo_Id = gruppoId;
            model.Query = Query;

            using (var rp = new GruppiRepository())
            {
                var g = rp.Get();
                model.Gruppi = TinyMapper.Map<List<HomeIndexGruppoVM>>(g);
            }

            using (var rp = new PersoneRepository())
            {
                var p = rp.Get(gruppoId, Query);
                model.Persone = p.Select(a => new HomeIndexPersonaVM
                {
                    Id = a.Id,
                    NomeCompleto = a.Nome + " " + a.Cognome,
                    RecapitoPrincipale = a.RecapitoPrincipale
                });
            }

            return View(model);
        }
    }
}