using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularMvcAPI.Models;

namespace AngularMvcAPI.Controllers
{
    public class HomeController1 : Controller
    {

        scidataEntities db = new scidataEntities();
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}


        //[HttpPost]
        ////public JsonResult CreateCustomer(Customer model)
        //    public JsonResult CreateCustomer()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Data save to database  
        //        return Json(new
        //        {
        //            success = true
        //        });
        //    }
        //    return Json(new
        //    {
        //        success = false,
        //        errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
        //    });
        //}





     
            // GET: Home  
            public ActionResult Index()
            {
                return View();
            }
            [HttpPost]
        ////public JsonResult CreateCustomer(Customer model)
        public JsonResult CreateCustomer(tb_Company model)
     
            {
                if (ModelState.IsValid)
                {
            
                    //Data save to database  
                    var RedirectUrl = Url.Action("About", "Home", new
                    {
                        area = ""
                    });
                    return Json(new
                    {
                        success = true,
                        redirectUrl = RedirectUrl
                    });
                }
                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                });
            }
            // GET: Home/About  
            public ActionResult About()
            {
                return View();
            }
        }

    


}