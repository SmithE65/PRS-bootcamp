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
    public class MessagesController : Controller
    {
        private PRS_bootcampContext db = new PRS_bootcampContext();

        const string bind = "Id, SenderId, ReceiverId, Text, TimeStamp, IsRead";

        public ActionResult Add([System.Web.Http.FromBody] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                int numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Msg { Result = "Error", Message = "ModelState invalid." });
        }

        public ActionResult Get(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "Get: id invalid or null." });

            Message message = db.Messages.Find(id);
            if (message == null)
                return Json(new Msg { Result = "Error", Message = "Get: id invalid." });

            return new JsonNetResult { Data = message };
        }

        public ActionResult GetByUser(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "GetByUser: id invalid or null." });

            User user = db.Users.Find(id);
            if (user == null)
                return Json(new Msg { Result = "Error", Message = "GetByUser: id invalid." });

            return new JsonNetResult { Data = db.Messages.Where(m => m.ReceiverId == user.Id) };
        }

        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Messages.ToList() };
        }

        public ActionResult Remove(int? id)
        {
            if (id == null || id <= 0)
                return Json(new Msg { Result = "Error", Message = "Remove: id invalid or null." });

            Message message = db.Messages.Find(id);
            if (message == null)
                return Json(new Msg { Result = "Error", Message = "Remove: id invalid." });

            db.Messages.Remove(message);
            int numChanges = db.SaveChanges();

            return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([System.Web.Http.FromBody] Message message)
        {
            if (message == null)
                return Json(new Msg { Result = "Error", Message = "Update: null message." });

            Message dbMessage = db.Messages.Find(message.Id);
            if (dbMessage == null)
                return Json(new Msg { Result = "Error", Message = "Update: invalid id" });

            dbMessage.Copy(message);

            if (ModelState.IsValid)
            {
                int numChanges = db.SaveChanges();
                return Json(new Msg { Result = "Success", Message = $"{numChanges} record(s) updated." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Msg { Result = "Error", Message = "Update: ModelState invalid." });
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
