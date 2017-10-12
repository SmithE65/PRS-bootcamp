using System.Linq;
using System.Web.Mvc;
using PRS_bootcamp.Models;
using PRS_bootcamp.Utilities;

namespace PRS_bootcamp.Controllers
{
    public class VendorsController : Controller
    {
        private PRS_bootcampContext db = new PRS_bootcampContext();

        private const string bind = "Id,Code,Name,Address,City,State,Zip,Phone,Email,IsPreapproved";

        public ActionResult Add([Bind(Include = bind)] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                int numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Msg { Result = "Error", Message = "ModelState invalid" });
        }

        public ActionResult Get(int? id)
        {
            if (id == null)
                return Json(new Msg { Result = "Failed", Message = "ID is null" });

            Vendor vendor = db.Vendors.Find(id);

            if (vendor == null)
            {
                return Json(new Msg { Result = "Failed", Message = $"No user found with id: {id}." }, JsonRequestBehavior.AllowGet);
            }

            return new JsonNetResult { Data = vendor };
        }

        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Vendors.ToList() };
        }

        public ActionResult Remove(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "id either null or invalid" });

            Vendor vendor = db.Vendors.Find(id);

            if (vendor == null)
                return Json(new Msg { Result = "Error", Message = "Invalid user id." });

            db.Vendors.Remove(vendor);
            int numChanges = db.SaveChanges();

            return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([Bind(Include = bind)] Vendor vendor)
        {
            if (vendor == null)
            {
                return Json(new Msg { Result = "Error", Message = "Update: vendor cannot be null." });
            }

            Vendor dbVendor = db.Vendors.Find(vendor.Id);

            if (dbVendor == null)
            {
                return Json(new Msg { Result = "Error", Message = $"Update: invalid id: {vendor.Id}" }, JsonRequestBehavior.AllowGet);
            }
            dbVendor.Copy(vendor);

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
