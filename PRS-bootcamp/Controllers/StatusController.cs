using System.Linq;
using System.Web.Mvc;
using PRS_bootcamp.Models;
using PRS_bootcamp.Utilities;

namespace PRS_bootcamp.Controllers
{
    public class StatusController : Controller
    {
        private PRS_bootcampContext db = new PRS_bootcampContext();

        private const string bind = "Id,Description";

        public ActionResult Add([Bind(Include = bind)] Status status)
        {
            if (ModelState.IsValid)
            {
                db.Status.Add(status);
                int numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Msg { Result = "Error", Message = "ModelState invalid" });
        }

        public ActionResult Get(int? id)
        {
            if (id == null)
                return Json(new Msg { Result = "Failed", Message = "ID is null" });

            Status status = db.Status.Find(id);

            if (status == null)
            {
                return Json(new Msg { Result = "Failed", Message = $"No user found with id: {id}." }, JsonRequestBehavior.AllowGet);
            }

            return new JsonNetResult { Data = status };
        }

        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Status.ToList() };
        }

        public ActionResult Remove(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "id either null or invalid" });

            Status status = db.Status.Find(id);

            if (status == null)
                return Json(new Msg { Result = "Error", Message = "Invalid status id." });

            db.Status.Remove(status);
            int numChanges = db.SaveChanges();

            return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([Bind(Include = bind)] Status status)
        {
            if (status == null)
            {
                return Json(new Msg { Result = "Error", Message = "Update: status cannot be null." });
            }

            Status dbStatus = db.Status.Find(status.Id);

            if (dbStatus == null)
            {
                return Json(new Msg { Result = "Error", Message = $"Update: invalid id: {status.Id}" }, JsonRequestBehavior.AllowGet);
            }
            dbStatus.Copy(status);

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
