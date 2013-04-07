using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookworms.Models;

namespace Bookworms.Controllers
{
    public class ReviewController : Controller
    {
        //
        // GET: /Review/

        [HttpGet]
        public ActionResult Add(int id)
        {
            ViewBag.IdBook = id;
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            sbartoszak_bookwormsEntities ent = new sbartoszak_bookwormsEntities();
            Review review = new Review();
            if (TryUpdateModel(review))
            {
                review.CreateDate = DateTime.Now;
                ent.Reviews.AddObject(review);
                ent.SaveChanges();
            }
            return RedirectToAction("Details", "Book", new { id = review.IdBook });
        }

    }
}
