using System.Linq;
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
