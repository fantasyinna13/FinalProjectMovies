using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProjectMovies.Entities;

namespace FinalProjectMovies.Controllers
{
    public class MovieToGenresController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: MovieToGenres
        public ActionResult Index()
        {
            var movieToGenres = db.MovieToGenres.Include(m => m.Genres).Include(m => m.Movie);
            return View(movieToGenres.ToList());
        }

        // GET: MovieToGenres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieToGenres movieToGenres = db.MovieToGenres.Find(id);
            if (movieToGenres == null)
            {
                return HttpNotFound();
            }
            return View(movieToGenres);
        }

        // GET: MovieToGenres/Create
        public ActionResult Create()
        {
            ViewBag.GenresID = new SelectList(db.Genre, "GenresID", "GenresName");
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title");
            return View();
        }

        // POST: MovieToGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieToGenresID,MovieID,GenresID")] MovieToGenres movieToGenres)
        {
            if (ModelState.IsValid)
            {
                db.MovieToGenres.Add(movieToGenres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenresID = new SelectList(db.Genre, "GenresID", "GenresName", movieToGenres.GenresID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", movieToGenres.MovieID);
            return View(movieToGenres);
        }

        // GET: MovieToGenres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieToGenres movieToGenres = db.MovieToGenres.Find(id);
            if (movieToGenres == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenresID = new SelectList(db.Genre, "GenresID", "GenresName", movieToGenres.GenresID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", movieToGenres.MovieID);
            return View(movieToGenres);
        }

        // POST: MovieToGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieToGenresID,MovieID,GenresID")] MovieToGenres movieToGenres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieToGenres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenresID = new SelectList(db.Genre, "GenresID", "GenresName", movieToGenres.GenresID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", movieToGenres.MovieID);
            return View(movieToGenres);
        }

        // GET: MovieToGenres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieToGenres movieToGenres = db.MovieToGenres.Find(id);
            if (movieToGenres == null)
            {
                return HttpNotFound();
            }
            return View(movieToGenres);
        }

        // POST: MovieToGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieToGenres movieToGenres = db.MovieToGenres.Find(id);
            db.MovieToGenres.Remove(movieToGenres);
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
    }
}
