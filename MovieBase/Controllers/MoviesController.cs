using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieBase.DAL;
using MovieBase.Models;
using Newtonsoft.Json;

namespace MovieBase.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Movies
        public ActionResult Index(string category, string search)
        {
            var movies = db.Movies.Include(m => m.Category);

            if (!String.IsNullOrEmpty(category))
            {
                movies = movies.Where(m => m.Category.Name == category);
            }

            if (!String.IsNullOrEmpty(search))
            {
                movies = movies.Where(m => m.Name.Contains(search) || 
                m.Description.Contains(search) || 
                m.Category.Name.Contains(search));
                ViewBag.Search = search;
            }

            var categories = movies.OrderBy(m => m.Category.Name).Select(m => m.Category.Name).Distinct();

            if (!String.IsNullOrEmpty(category))
            {
                movies = movies.Where(m => m.Category.Name == category);
            }

            ViewBag.Category = new SelectList(categories);

            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CategoryID,WhenWatched,MyRate")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", movie.CategoryID);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", movie.CategoryID);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CategoryID,WhenWatched,MyRate")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", movie.CategoryID);
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // ------------------------------------------------------------

       

        public ActionResult GetData()
        {
            return Json(new[] { new Movie()}, JsonRequestBehavior.AllowGet);
        }

        // JSON
        public JsonResult GetMovies()
        {

            Movie movie = new Movie()
            {
                Name = "Simpsons"
            };


            var json = JsonConvert.SerializeObject(movie);

            return Json(Json, JsonRequestBehavior.AllowGet);
        }

        private JsonResult Json(Func<object, JsonResult> json, JsonRequestBehavior allowGet)
        {
            throw new NotImplementedException();
        }
    }
}
