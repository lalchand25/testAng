using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularmvcAPI.Models;
namespace AngularmvcAPI.Controllers
{
    public class comApiController : ApiController
    {

        scidataEntities db = new scidataEntities();


        //  EmployeeDbContext db = new EmployeeDbContext();
        // GET api/employee  
        [ActionName("get"), HttpGet]
        public IEnumerable<tb_Company> Emps()
        {
            return db.tb_Company.ToList();
        }
        // GET api/employee/5  
        public tb_Company Get(int id)
        {
            return db.tb_Company.Find(id);
        }
        // POST api/employee  
        public HttpResponseMessage Post(tb_Company model)
        {
            if (ModelState.IsValid)
            {
                db.tb_Company.Add(model);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // PUT api/employee/5  
        public HttpResponseMessage Put(tb_Company model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // DELETE api/employee/5  
        public HttpResponseMessage Delete(int id)
        {
            tb_Company emp = db.tb_Company.Find(id);
            if (emp == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.tb_Company.Remove(emp);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, emp);
        }


    }
}
