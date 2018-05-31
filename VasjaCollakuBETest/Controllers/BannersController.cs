using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using VasjaCollakuBETest.Models;

namespace VasjaCollakuBETest.Controllers
{
    public class BannersController : Controller
    {
        private BannerDBContext db = new BannerDBContext();

        // GET: Banners
        public ActionResult Index()
        {
            return View(db.Banners.ToList());
        }

        // GET: Banners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // GET: Banners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Html,Created,Modified")] Banner banner)
        {
            if (ModelState.IsValid && validateHTML(banner.Html))
            {
                banner.Created = DateTime.Now;
                banner.Modified = null;
                db.Banners.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banner);
        }

        // GET: Banners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Banners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Html,Created,Modified")] Banner banner)
        {
            if (ModelState.IsValid && validateHTML(banner.Html))
            {
                //banner.Created = DateTime.Now;
                banner.Modified = DateTime.Now;
                db.Entry(banner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banner);
        }

        // GET: Banners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banner banner = db.Banners.Find(id);
            db.Banners.Remove(banner);
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

        [ValidateInput(false)]
        public ActionResult Render(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }


        private static bool HtmlIsJustText(HtmlNode rootNode)
        {
            return rootNode.Descendants().All(n => n.NodeType == HtmlNodeType.Text);
        }

        public Boolean validateHTML(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return !HtmlIsJustText(doc.DocumentNode);

          
        }
    }
}

