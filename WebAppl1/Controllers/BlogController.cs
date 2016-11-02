using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Web;
 using System.Web.Mvc;
 
 namespace WebAppl1.Controllers
 {
     public class BlogController : Controller
     {
         // GET: Blog
         public ActionResult Index(string rob)
         {
             var db = new BlogDatabase();
 
            db.Database.CreateIfNotExists();
 
             var lst = db.BlogArticles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(rob))
              {
                lst = lst.Where(o => o.Subject.Contains(rob));

            }
            
            ViewBag.BlogArticles = lst.OrderByDescending(o => o.Id).ToList();
            ViewBag.rob = rob;


            return View();
         }
 
 
         public ActionResult AddArticle()
         {
             return View();
         }
 
         public ActionResult ArticleSave(string subject, string body)
         {
             var article = new BlogArticle();
             article.Subject = subject;
             article.Body = body;
             article.DateCreated = DateTime.Now;
 
             var db = new BlogDatabase();
             db.BlogArticles.Add(article);
             db.SaveChanges();
 
             return Redirect("Index");
         }
 
         public ActionResult Show(int id)
         {
             var db = new BlogDatabase();
             var article = db.BlogArticles.First(o => o.Id == id);
 
            ViewData.Model = article;
             return View();
         }
        public ActionResult Edit(int id)
        {
            var db = new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == id);

            ViewData.Model = article;
            return View();
        }

        public ActionResult EditSave(int id, string subject, string body)
        {
            var db = new BlogDatabase();
            var article = db.BlogArticles.First(o => o.Id == id);

            article.Subject = subject;
            article.Body = body;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
             var db = new BlogDatabase();
             var article = db.BlogArticles.First(o => o.Id == id);
 
             db.BlogArticles.Remove(article);
            db.SaveChanges();
 
             return RedirectToAction("Index");
         }
      
    }
} 