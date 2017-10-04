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

        public ActionResult Add([Bind(Include = bind)] PurchaseRequest purchaseRequest)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequests.Add(purchaseRequest);
                int numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." });
            }

            return Json(new Msg { Result = "Error", Message = "ModelState invalid" });
        }

        public ActionResult Get(int? id)
        {
            if (id == null)
                return Json(new Msg { Result = "Failed", Message = "ID is null" });

            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);

            if (purchaseRequest == null)
            {
                return Json(new Msg { Result = "Failed", Message = $"No user found with id: {id}." });
            }

            return new JsonNetResult { Data = purchaseRequest };
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
                return Json(new Msg { Result = "Error", Message = "Invalid user id." });

            db.PurchaseRequests.Remove(purchaseRequest);
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
