using System.Linq;
using System.Web.Mvc;
using PRS_bootcamp.Models;
using PRS_bootcamp.Utilities;

namespace PRS_bootcamp.Controllers
{
    public class ProductsController : Controller
    {
        private PRS_bootcampContext db = new PRS_bootcampContext();
        private const string bind = "Id,VendorId,VendorPartNumber,Name, Description,Price,Unit,Photopath";

        public ActionResult Add([Bind(Include = bind)] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                int numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Msg { Result = "Error", Message = "ModelState invalid" });
        }

        public ActionResult Get(int? id)
        {
            if (id == null)
                return Json(new Msg { Result = "Failed", Message = "ID is null" });

            Product product = db.Products.Find(id);

            if (product == null)
            {
                return Json(new Msg { Result = "Failed", Message = $"No user found with id: {id}." });
            }

            return new JsonNetResult { Data = product };
        }

        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Products.ToList() };
        }

        public ActionResult Remove(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "id either null or invalid" });

            Product product = db.Products.Find(id);

            if (product == null)
                return Json(new Msg { Result = "Error", Message = "Invalid user id." });

            db.Products.Remove(product);
            int numChanges = db.SaveChanges();

            return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([Bind(Include = bind)] Product product)
        {
            if (product == null)
            {
                return Json(new Msg { Result = "Error", Message = "Update: product cannot be null." });
            }

            Product dbProduct = db.Products.Find(product.Id);

            if (dbProduct == null)
            {
                return Json(new Msg { Result = "Error", Message = $"Update: invalid id: {product.Id}" }, JsonRequestBehavior.AllowGet);
            }
            dbProduct.Copy(product);

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
