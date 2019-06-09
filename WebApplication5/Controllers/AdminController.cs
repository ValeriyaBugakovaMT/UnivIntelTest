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
     
        public ActionResult addUser()
        {
            return View();
        }
        public ActionResult showDictCities()
        {
            var model = db.DictCities.ToList();
            return View(model);
        }
        public string RemoveCity(string code)
        {
            var city = db.DictCities.SingleOrDefault(m => m.Code ==code);
            db.DictCities.Remove(city);
            db.SaveChanges();
            return "true";
        }
        public string ChangeCity(string OLDCode,string Code, string Title)
        {
            var city = db.DictCities.SingleOrDefault(m => m.Code == OLDCode);
            city.Code = Code;
            city.Title = Title;
            db.SaveChanges();
            return "true";
        }
    }
}