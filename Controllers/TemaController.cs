using CombosDependientes.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CombosDependientes.Controllers
{
    public class TemaController : Controller
    {
        // GET: Tema
        public ActionResult Index()
        {
            List<SelectListItem> LstTema = new List<SelectListItem>();
            using (bdTestEntities db = new bdTestEntities())
            {
                LstTema = (from t in db.Tema
                       orderby t.Nombre
                       select new SelectListItem {
                           Value = t.Id.ToString(),
                           Text = t.Nombre.ToUpper() }).ToList();
            }
            ViewBag.DDLtema = new SelectList(LstTema, "Value", "Text");
            return View();
        }
        [HttpGet]
        public JsonResult ListarSubtema(int TemaId)
        {
            List<SelectListItem> LstSubtema = new List<SelectListItem>();
            using (bdTestEntities db=new bdTestEntities())
            {
                LstSubtema = (from s in db.Subtema
                              where s.Tema_id == TemaId
                              orderby s.Nombre
                              select new SelectListItem
                              {
                                  Value = s.Id.ToString(),
                                  Text = s.Nombre
                              }).ToList();
            }
            return Json(LstSubtema, JsonRequestBehavior.AllowGet);
        }
    }
}