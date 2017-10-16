using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PRS_bootcamp.Models;
using PRS_bootcamp.Utilities;

namespace PRS_bootcamp.Controllers
{
    public class PurchaseRequestsController : Controller
    {
        private PRS_bootcampContext db = new PRS_bootcampContext();

        private const string bind = "Id,UserId,Description,Justification,DateNeeded,DeliveryMode,StatusId,Total,SubmittedDate,ReasonForRejection";

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

        public ActionResult Add([Bind(Include = bind)] PurchaseRequest purchaseRequest)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequests.Add(purchaseRequest);
                int numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Msg { Result = "Error", Message = "ModelState invalid" });
        }

        public ActionResult Get(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "Get: id either null or invalid" });

            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);

            if (purchaseRequest == null)
            {
                return Json(new Msg { Result = "Error", Message = $"No user found with id: {id}." }, JsonRequestBehavior.AllowGet);
            }

            return new JsonNetResult { Data = purchaseRequest };
        }

        public ActionResult GetItems(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "GetItems: id either null or invalid" });

            List<PurchaseRequestLineItem> items = db.PurchaseRequestLineItems.Where(li => li.PurchaseRequestId == id).ToList();

            return new JsonNetResult { Data = items };
        }

        public ActionResult List()
        {
            return new JsonNetResult { Data = db.PurchaseRequests.ToList() };
        }

        public ActionResult Remove(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "id either null or invalid" });

            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);

            if (purchaseRequest == null)
                return Json(new Msg { Result = "Error", Message = "Invalid request id." });

            db.PurchaseRequests.Remove(purchaseRequest);
            int numChanges = db.SaveChanges();

            return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([Bind(Include = bind)] PurchaseRequest purchaseRequest)
        {
            if (purchaseRequest == null)
            {
                return Json(new Msg { Result = "Error", Message = "Update: purchase req cannot be null." });
            }

            PurchaseRequest dbPurchaseRequest = db.PurchaseRequests.Find(purchaseRequest.Id);

            if (dbPurchaseRequest == null)
            {
                return Json(new Msg { Result = "Error", Message = $"Update: invalid id: {purchaseRequest.Id}" }, JsonRequestBehavior.AllowGet);
            }
            dbPurchaseRequest.Copy(purchaseRequest);

            int numChanges = 0;
            if (ModelState.IsValid)
            {
                numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) updated." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Msg { Result = "Error", Message = $"ModelState invalid; {numChanges} record(s) updated." }, JsonRequestBehavior.AllowGet);
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
