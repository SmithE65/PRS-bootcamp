﻿using System.Linq;
using System.Web.Mvc;
using PRS_bootcamp.Models;
using PRS_bootcamp.Utilities;

namespace PRS_bootcamp.Controllers
{
    public class PurchaseRequestLineItemsController : Controller
    {
        private PRS_bootcampContext db = new PRS_bootcampContext();
        private const string bind = "Id,PurchaseRequestId,ProductId,Quantity";

        public ActionResult UpdateTotal(int? id)
        {
            if (id == null || id <= 0)
            {
                return Json(new Msg { Result = "Error", Message = "Invalid id." }, JsonRequestBehavior.AllowGet);
            }

            var purchaseRequest = db.PurchaseRequests.Find(id);

            if (purchaseRequest == null)
            {
                return Json(new Msg { Result = "Error", Message = $"No PurchaseRequest found for id: {id}" }, JsonRequestBehavior.AllowGet);
            }

            var lineItems = db.PurchaseRequestLineItems.Where(p => p.PurchaseRequestId == purchaseRequest.Id).ToList();

            decimal total = 0;
            foreach (var item in lineItems)
            {
                total += item.Product.Price * item.Quantity;
            }
            purchaseRequest.Total = total;

            int numChanged = 0;
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequest).State = System.Data.Entity.EntityState.Modified;
                numChanged = db.SaveChanges();
            }

            return Json(new Msg { Result = "Success", Message = $"{numChanged} record(s) changed with total: {total}" }, JsonRequestBehavior.AllowGet);
        }

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
