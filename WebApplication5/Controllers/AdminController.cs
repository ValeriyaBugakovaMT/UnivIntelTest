using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{

    public class AdminController : Controller
    {
        Project1 db = new Project1();
        public ActionResult Index()
        {
            return View(db.DictCities.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DictCities book)
        {
            db.DictCities.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: Admin
     
        public string addUser(string Title, string Code)
        {
            Guid id = Guid.NewGuid();
            string text = Title;
            string code = Code;
            DictCities city = new DictCities { ID = id, Title = text, Code = code };
            db.DictCities.Add(city);
            
            db.SaveChanges();
            return "true";
        }
        public ActionResult showDictCities()
        {
            var model = db.DictCities.ToList();
            return View(model);
        }
    }
}