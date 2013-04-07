using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookworms.Models;
using Bookworms.ViewModel;

namespace Bookworms.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/

        public ActionResult Index()
        {
            sbartoszak_bookwormsEntities ent = new sbartoszak_bookwormsEntities();
            var book = from b in ent.Books
                       orderby b.Author
                       select new BookVM() { Title = b.Title, Author = b.Author, GenreName = b.Genre.Name, AddDate = b.AddDate, IdBook = b.IdBook };
            return View(book);
        }

        [HttpGet]
        public ActionResult Add()
        {
            sbartoszak_bookwormsEntities ent = new sbartoszak_bookwormsEntities();
            ViewBag.BookGenres = ent.Genres.OrderBy(g => g.Name).ToSelectListItem(1, g => g.IdGenre, g => g.Name, g => g.Name, g => g.IdGenre.ToString());
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            sbartoszak_bookwormsEntities ent = new sbartoszak_bookwormsEntities();
            ViewBag.BookGenres = ent.Genres.OrderBy(g => g.Name).ToSelectListItem(1, g => g.IdGenre, g => g.Name, g => g.Name, g => g.IdGenre.ToString());
            Book book = new Book();
            if (TryUpdateModel(book))
            {
                book.AddDate = DateTime.Now;
                ent.Books.AddObject(book);
                ent.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            sbartoszak_bookwormsEntities ent = new sbartoszak_bookwormsEntities();
            BookVM book = (from b in ent.Books
                       where b.IdBook == id
                       select new BookVM() { Title = b.Title, Author = b.Author, GenreName = b.Genre.Name, AddDate = b.AddDate, IdBook = b.IdBook }).FirstOrDefault();
            book.Reviews = (from r in ent.Reviews
                            where r.IdBook == book.IdBook
                            select r).ToList();
            return View(book);
        }
    }
}
