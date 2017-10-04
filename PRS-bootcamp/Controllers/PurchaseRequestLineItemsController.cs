using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRS_bootcamp.Models;
using PRS_bootcamp.Utilities;

namespace PRS_bootcamp.Controllers
{
    public class PurchaseRequestLineItemsController : Controller
    {
        private PRS_bootcampContext db = new PRS_bootcampContext();

        private const string bind = "Id,PurchaseRequestId,ProductId,Quantity";

        public ActionResult Add([Bind(Include = bind)] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
                int numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." });
            }

            return Json(new Msg { Result = "Error", Message = "ModelState invalid" });
        }

        public ActionResult Get(int? id)
        {
            if (id == null)
                return Json(new Msg { Result = "Failed", Message = "ID is null" });

            PurchaseRequestLineItem purchaseRequestLine = db.PurchaseRequestLineItems.Find(id);

            if (purchaseRequestLine == null)
            {
                return Json(new Msg { Result = "Failed", Message = $"No user found with id: {id}." });
            }

            return new JsonNetResult { Data = purchaseRequestLine };
        }

        public ActionResult List()
        {
            return new JsonNetResult { Data = db.PurchaseRequestLineItems.ToList() };
        }

        public ActionResult Remove(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "id either null or invalid" });

            PurchaseRequestLineItem purchaseRequestLine = db.PurchaseRequestLineItems.Find(id);

            if (purchaseRequestLine == null)
                return Json(new Msg { Result = "Error", Message = "Invalid user id." });

            db.PurchaseRequestLineItems.Remove(purchaseRequestLine);
            int numChanges = db.SaveChanges();

            return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." });
        }

        #region MVC_Actions
        // GET: PurchaseRequestLineItems
        public ActionResult Index()
        {
            var purchaseRequestLineItems = db.PurchaseRequestLineItems.Include(p => p.Product).Include(p => p.PurchaseRequest);
            return View(purchaseRequestLineItems.ToList());
        }

        // GET: PurchaseRequestLineItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequestLineItem);
        }

        // GET: PurchaseRequestLineItems/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "VendorPartNumber");
            ViewBag.PurchaseRequestId = new SelectList(db.PurchaseRequests, "Id", "Description");
            return View();
        }

        // POST: PurchaseRequestLineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PurchaseRequestId,ProductId,Quantity")] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "VendorPartNumber", purchaseRequestLineItem.ProductId);
            ViewBag.PurchaseRequestId = new SelectList(db.PurchaseRequests, "Id", "Description", purchaseRequestLineItem.PurchaseRequestId);
            return View(purchaseRequestLineItem);
        }

        // GET: PurchaseRequestLineItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "VendorPartNumber", purchaseRequestLineItem.ProductId);
            ViewBag.PurchaseRequestId = new SelectList(db.PurchaseRequests, "Id", "Description", purchaseRequestLineItem.PurchaseRequestId);
            return View(purchaseRequestLineItem);
        }

        // POST: PurchaseRequestLineItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PurchaseRequestId,ProductId,Quantity")] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequestLineItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "VendorPartNumber", purchaseRequestLineItem.ProductId);
            ViewBag.PurchaseRequestId = new SelectList(db.PurchaseRequests, "Id", "Description", purchaseRequestLineItem.PurchaseRequestId);
            return View(purchaseRequestLineItem);
        }

        // GET: PurchaseRequestLineItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequestLineItem);
        }

        // POST: PurchaseRequestLineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            db.PurchaseRequestLineItems.Remove(purchaseRequestLineItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
#endregion

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
