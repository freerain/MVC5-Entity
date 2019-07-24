using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        // создаем контекст данных
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            //// получаем из бд все объекты Book
            //IEnumerable<Book> books = db.Books;
            //// передаем все объекты в динамическое свойство Books в ViewBag
            //ViewBag.Books = books;
            //// возвращаем представление
            return View(db.Books);
        }

        // асинхронный метод
        public async Task<ActionResult> BookList()
        {
            IEnumerable<Book> books = await db.Books.ToListAsync();
            ViewBag.Books = books;
            return View("Index");
        }


        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View("Buy");
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = getToday();
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }
        private DateTime getToday()
        {
            return DateTime.Now;
        }


        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}