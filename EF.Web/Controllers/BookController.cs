using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EF.Core.Data;
using EF.Data;

namespace EF.Web.Controllers
{
    public class BookController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Book> bookRepository;

        public BookController()
        {
            bookRepository = unitOfWork.Repository<Book>();
        }

        public ActionResult Index()
        {
            IEnumerable<Book> books = bookRepository.Table.ToList();
            return View(books);
        }

        public ActionResult CreateEditBook(int? id)
        {
            Book model = new Book();
            if (id.HasValue)
            {
                model = bookRepository.GetById(id.Value);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditBook(Book model)
        {
            if (model.ID == 0)
            {
                model.ModifiedDate = System.DateTime.Now;
                model.AddedDate = System.DateTime.Now;
                model.IP = Request.UserHostAddress;
                bookRepository.Insert(model);
            }
            else
            {
                var editModel = bookRepository.GetById(model.ID);
                editModel.Title = model.Title;
                editModel.Author = model.Author;
                editModel.ISBN = model.ISBN;
                editModel.Published = model.Published;
                editModel.ModifiedDate = System.DateTime.Now;
                editModel.IP = Request.UserHostAddress;
                bookRepository.Update(editModel);
            }

            if (model.ID > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult DeleteBook(int id)
        {
            Book model = bookRepository.GetById(id);
            return View(model);
        }

        [HttpPost,ActionName("DeleteBook")]
        public ActionResult ConfirmDeleteBook(int id)
        {
            Book model = bookRepository.GetById(id);
            bookRepository.Delete(model);
            return RedirectToAction("Index");
        }

        public ActionResult DetailBook(int id)
        {
            Book model = bookRepository.GetById(id);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
