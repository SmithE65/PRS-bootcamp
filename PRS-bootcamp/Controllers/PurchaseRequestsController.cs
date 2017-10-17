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

        public class Cart
        {
            public PurchaseRequest request { get; set; }
            public List<PurchaseRequestLineItem> lineitems { get; set; }
        }

        private const string bind = "Id,UserId,Description,Justification,DateNeeded,DeliveryMode,StatusId,Total,SubmittedDate,ReasonForRejection";

        /// <summary>
        /// Sums all LineItems where PurchaseRequestId matches id
        /// </summary>
        /// <param name="id">PurchaseRequest Id</param>
        /// <returns>JSON formatted success or error messages.</returns>
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

        public ActionResult GetCart(int? id)
        {
            if (id == null || id <= 0)
            {
                return Json(new Msg { Result = "Error", Message = "GetCart: id either null or invalid" }, JsonRequestBehavior.AllowGet);
            }

            PurchaseRequest pr = db.PurchaseRequests.Find(id);
            if (pr == null)
            {
                return Json(new Msg { Result = "Error", Message = "GetCart: invalid request id." });
            }

            var lineitems = db.PurchaseRequestLineItems.Where(i => i.PurchaseRequestId == pr.Id).ToList();

            return new JsonNetResult { Data = new Cart { request = pr, lineitems = lineitems } };
        }

        public ActionResult GetByUser(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "GetByUser: id either null or invalid" });

            return new JsonNetResult { Data = db.PurchaseRequests.Where(r => r.UserId == id).ToList() };
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

        public ActionResult UpdateCart([System.Web.Http.FromBody] Cart cart)
        {
            if (cart.request == null)
            {
                return Json(new Msg { Result = "Error", Message = "Cart: null request." }, JsonRequestBehavior.AllowGet);
            }

            PurchaseRequest pr = db.PurchaseRequests.Find(cart.request.Id);
            if (pr == null)
            {
                return Json(new Msg { Result = "Error", Message = "Cart: invalid Id." }, JsonRequestBehavior.AllowGet);
            }
            pr.Copy(cart.request);

            if (cart.lineitems != null)
            {
                PurchaseRequestLineItem item = null;
                foreach (PurchaseRequestLineItem li in cart.lineitems)
                {
                    item = db.PurchaseRequestLineItems.Find(li.Id);
                    if (item == null)
                    {
                        db.PurchaseRequestLineItems.Add(li);
                    }
                    else
                    {
                        item.Copy(li);
                    }
                }
            }

            int numChanges = 0;
            if (ModelState.IsValid)
            {
                numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"Cart: {numChanges} items updated." }, JsonRequestBehavior.AllowGet);
            }
            UpdateTotal(pr.Id);

            return Json(new Msg { Result = "Error", Message = "Cart: ModelState invalid." }, JsonRequestBehavior.AllowGet);
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
