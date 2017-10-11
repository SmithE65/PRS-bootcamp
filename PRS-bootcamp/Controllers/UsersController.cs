using System.Linq;
using System.Web.Mvc;
using PRS_bootcamp.Models;
using PRS_bootcamp.Utilities;
using System.Collections.Generic;

namespace PRS_bootcamp.Controllers
{
    public class UsersController : Controller
    {
        private PRS_bootcampContext db = new PRS_bootcampContext();
        private const string bind = "Id, UserName, Password, FirstName, LastName, Phone, Email, IsAdmin, IsReviewer";

        public ActionResult Add([Bind(Include = bind)] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                int numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Msg { Result = "Error", Message = "Add: ModelState invalid" });
        }

        public ActionResult Get(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "Get: id either null or invalid" });

            User user = db.Users.Find(id);

            if (user == null)
            {
                return Json(new Msg { Result = "Error", Message = $"Get: invalid user id: {id}." }, JsonRequestBehavior.AllowGet);
            }

            return new JsonNetResult { Data = user };
        }

        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Users.ToList() };
        }

        public ActionResult Login(string UserName, string Password)
        {
            return new JsonNetResult { Data = db.Users.Where(u => u.UserName == UserName && u.Password == Password).ToList() };
        }

        public ActionResult Remove(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "Remove: id either null or invalid" });

            User user = db.Users.Find(id);

            if (user == null)
                return Json(new Msg { Result = "Error", Message = "Remove: invalid user id." });

            db.Users.Remove(user);
            int numChanges = db.SaveChanges();

            return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([Bind(Include = bind)] User user)
        {
            if (user == null)
            {
                return Json(new Msg { Result = "Error", Message = "Update: user cannot be null." });
            }

            User dbUser = db.Users.Find(user.Id);

            if (dbUser == null)
            {
                return Json(new Msg { Result = "Error", Message = $"Update: invalid id: {user.Id}" }, JsonRequestBehavior.AllowGet);
            }
            dbUser.Copy(user);

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
