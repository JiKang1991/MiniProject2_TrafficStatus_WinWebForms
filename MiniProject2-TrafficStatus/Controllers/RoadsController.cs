using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniProject2_TrafficStatus.Context;
using MiniProject2_TrafficStatus.Models;

namespace MiniProject2_TrafficStatus.Controllers
{
    public class RoadsController : Controller
    {
        private RoadDAO db = new RoadDAO();

        // GET: Roads
        public ActionResult Index()
        {
            return View(db.Roads.ToList());
        }

        // GET: Roads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Road road = db.Roads.Find(id);
            if (road == null)
            {
                return HttpNotFound();
            }
            return View(road);
        }

        // GET: Roads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roads/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,roadNumber,roadName,startLocX,startLocY,finishLocX,finishLocY")] Road road)
        {
            if (ModelState.IsValid)
            {
                db.Roads.Add(road);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(road);
        }

        // GET: Roads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Road road = db.Roads.Find(id);
            if (road == null)
            {
                return HttpNotFound();
            }
            return View(road);
        }

        // POST: Roads/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,roadNumber,roadName,startLocX,startLocY,finishLocX,finishLocY")] Road road)
        {
            if (ModelState.IsValid)
            {
                db.Entry(road).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(road);
        }

        // GET: Roads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Road road = db.Roads.Find(id);
            if (road == null)
            {
                return HttpNotFound();
            }
            return View(road);
        }

        // POST: Roads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Road road = db.Roads.Find(id);
            db.Roads.Remove(road);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StatusView()
        {
            return View();
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
