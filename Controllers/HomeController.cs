using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularMvcAPI.Models;

namespace AngularMvcAPI.Controllers
{
    public class HomeController : Controller
    {

        scidataEntities db = new scidataEntities();





        //private tb_CompanyServiceobjCust;  
        //public HomeController()
        //{
        //    this.objCust = new tb_CompanyService();
        //}
        // GET: Home  
        public ActionResult Index()
        {
            return View();
        }
        // GET: All tb_Company  
        [HttpGet]
        public JsonResult GetAllData()
        {
            int Count = 10;
            IEnumerable<object> tb_Companys = null;
            try
            {
                object[] parameters = {
                Count
            };
                tb_Companys = from m in db.tb_Company select m; ;
            }
            catch
            { }
            return Json(tb_Companys.ToList(), JsonRequestBehavior.AllowGet);
        }
        // GET: Get Single tb_Company  
        [HttpGet]
        public JsonResult GetbyID(int id)
        {
            object tb_Company = null;
            try
            {
                object[] parameters = {
                id
            };
                tb_Company = (from m in db.tb_Company where m.CompanyID == id select m).Single();
            }
            catch
            { }
            return Json(tb_Company, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Insert()
        {
            return View();
        }
        // POST: Save New tb_Company  
        [HttpPost]
        public JsonResult Insert(tb_Company model)
        {
            int result = 0;
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    object[] parameters = {
                    model.Address,
                    model.Cell

                };
                    db.tb_Company.Add(model);
                    db.SaveChanges();

                    // result = objCust.Insert(parameters);
                    if (result == 1)
                    {
                        status = true;
                    }
                    return Json(new
                    {
                        success = status
                    });
                }
                catch
                { }
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
        }
        public ActionResult Update()
        {
            return View();
        }
        // POST: Update Existing tb_Company  
        [HttpPost]
        public JsonResult Update(tb_Company model)
        {
            int result = 0;
            bool status = false;
            //if (ModelState.IsValid)
            //{
                try
                {
                    object[] parameters = {
                    model.CompanyID,
                    model.Address,
                    model.Cell
                };

                    var tb_Company = (from m in db.tb_Company where m.CompanyID == model.CompanyID select m).Single();

                    tb_Company.Address = model.Address;
             
                    db.SaveChanges();
                    result = 1;

                    //  result = objCust.Update(parameters);
                    if (result == 1)
                    {
                        status = true;
                    }
                    return Json(new
                    {
                        success = status
                    });
                }
                catch
                { }
          //  }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
        }
        // DELETE: Delete tb_Company  
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            int result = 0;
            bool status = false;
           // try
           // {
                object[] parameters = {
                id
            };

                var tb_Company = (from m in db.tb_Company where m.CompanyID == id select m).Single();

                db.tb_Company.Remove(tb_Company);

                db.SaveChanges();
            result = 1;

            // result = objCust.Delete(parameters);
            if (result == 1)
                {
                    status = true;
                }
          //  }
           // catch
           // { }
            return Json(new
            {
                success = status
            });
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}