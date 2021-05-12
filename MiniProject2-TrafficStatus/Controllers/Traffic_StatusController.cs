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
    public class Traffic_StatusController : Controller
    {
        private TrafficStatusDAO db = new TrafficStatusDAO();

        // GET: Traffic_Status
        public ActionResult Index()
        {
            return View(db.tsDbSet.ToList());
        }

        // GET: Traffic_Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traffic_Status traffic_Status = db.tsDbSet.Find(id);
            if (traffic_Status == null)
            {
                return HttpNotFound();
            }
            return View(traffic_Status);
        }

        // GET: Traffic_Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Traffic_Status/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,r_id,ts_speed,ts_loc_x,ts_loc_y,time")] Traffic_Status traffic_Status)
        {
            if (ModelState.IsValid)
            {
                db.tsDbSet.Add(traffic_Status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(traffic_Status);
        }

        // GET: Traffic_Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traffic_Status traffic_Status = db.tsDbSet.Find(id);
            if (traffic_Status == null)
            {
                return HttpNotFound();
            }
            return View(traffic_Status);
        }

        // POST: Traffic_Status/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,r_id,ts_speed,ts_loc_x,ts_loc_y,time")] Traffic_Status traffic_Status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traffic_Status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traffic_Status);
        }

        // GET: Traffic_Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traffic_Status traffic_Status = db.tsDbSet.Find(id);
            if (traffic_Status == null)
            {
                return HttpNotFound();
            }
            return View(traffic_Status);
        }

        // POST: Traffic_Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Traffic_Status traffic_Status = db.tsDbSet.Find(id);
            db.tsDbSet.Remove(traffic_Status);            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MainDoor()
        {
            ViewBag.roadName = db.GetRoadName();

            return View();
        }
        public ActionResult RTStatusView(int roadId)
        {   
            
            ViewBag.fabricationValue = db.GetFabricationValue(roadId);

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
