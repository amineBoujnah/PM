using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Terabyte.Domain.Entities;
using Terabyte.Service;
using Terabyte.Web.Models;

namespace Terabyte.Web.Controllers
{
    public class PublicationController : Controller
    {
        public PublicationService MyPublicationService;
        public CommentService MyCommentService;
        // GET: Publication
        public PublicationController()
        {
            MyPublicationService = new PublicationService();
            MyCommentService = new CommentService();
        }
        public ActionResult Index()
        {
            var Publications = new List<PublicationVM>();
            foreach (Publication p in MyPublicationService.GetMany())
            {
                Publications.Add(new PublicationVM() {
                    title = p.title,
                    description=p.description,
                    creationDate=p.creationDate,
                    image=p.image,
                    //OwnerId=p.OwnerId,
                    PublicationId=p.PublicationId,
                    visibility=(VisibilityVM)p.visibility
                });

            }
            return View(Publications);
        }

        // GET: Publication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication p;
            p = MyPublicationService.GetById((int)id);
            if (p == null) { return HttpNotFound(); }
            PublicationVM pvm = new PublicationVM() {creationDate=p.creationDate,
            description=p.description,
            image=p.image,
            //OwnerId=p.OwnerId,
            PublicationId=p.PublicationId,
            title=p.title,
            visibility=(VisibilityVM)p.visibility};
            GetComments((int)id);
            return View(pvm);
        }

        // GET: Publication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publication/Create
        [HttpPost]
        public ActionResult Create(PublicationVM PublicationVM, HttpPostedFileBase Image)
        {
           
            
            Publication PublicationDomain=new Publication() {
                title=PublicationVM.title,
                creationDate=DateTime.UtcNow,
                description=PublicationVM.description,
                visibility= (Visibility)PublicationVM.visibility,
                image= Image.FileName
                
            };
          
            MyPublicationService.Add(PublicationDomain);
            MyPublicationService.Commit();

            var path = Path.Combine(Server.MapPath("~/Content/Uploads"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");

        }

        // GET: Publication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Publication/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Publication/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Publication p= MyPublicationService.GetById(id);
            MyPublicationService.Delete(p);
            MyPublicationService.Commit();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
           
        }

        [HttpPost]
        public ActionResult CreateComment(string con,int id)
        {


            Comment comment = new Comment()
            {
              Contenu= con,
              PublicationId=id

            };

            MyCommentService.Add(comment);
            MyCommentService.Commit();
           


            return Json(comment,JsonRequestBehavior.AllowGet);

        }

        public PartialViewResult GetComments(int idpub)
        {
            var Comments = new List<CommentVM>();
            foreach (Comment p in MyCommentService.GetMany())
            {
                if (p.PublicationId ==idpub)
                {
                    Comments.Add(new CommentVM()
                    {
                        CommentId = p.CommentId,
                        Contenu = p.Contenu
                    });
                }
                

            }
            
            return PartialView("Comments",Comments);
        }

        [HttpPost]
        public PartialViewResult PostComment(string contenu, int idpub)
        {


            Comment comment = new Comment()
            {
                Contenu = contenu,
                PublicationId = idpub

            };

            MyCommentService.Add(comment);
            MyCommentService.Commit();

            var Comments = new List<CommentVM>();
            foreach (Comment p in MyCommentService.GetMany())
            {
                if (p.PublicationId == idpub)
                {
                    Comments.Add(new CommentVM()
                    {
                        CommentId = p.CommentId,
                        Contenu = p.Contenu
                    });
                }


            }

            return PartialView("Comments", Comments);

        }

        public ActionResult allcomments(int idpub)
        {
            var Comments = new List<CommentVM>();
            foreach (Comment p in MyCommentService.GetMany())
            {
                if (p.PublicationId == idpub)
                {
                    Comments.Add(new CommentVM()
                    {
                        CommentId = p.CommentId,
                        Contenu = p.Contenu
                    });
                }

            }
            return View(Comments);
        }

        public ActionResult AddOrEdit(int id=0)
        {
            CommentVM c = new CommentVM();
            return View(c);
        }
        [HttpPost]
        public ActionResult AddOrEdit(CommentVM cm, int id)
        {

            ViewBag.id = id;
            Comment comment = new Comment()
            {
                Contenu = cm.Contenu,
                PublicationId = 2

            };

            MyCommentService.Add(comment);
            MyCommentService.Commit();
            return RedirectToAction("allcomments");
        }
    }
}
