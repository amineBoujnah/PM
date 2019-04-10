using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Terabyte.Domain.Entities;
using Terabyte.Service;
using Terabyte.Web.Models;

namespace Terabyte.Web.Controllers
{
    public class ProjectController : Controller
    {
        IProjectService MyProjectService;
        ITeamService MyTeamService;
        public ProjectController()
        {
            MyProjectService = new ProjectService();
            MyTeamService = new TeamService();
        }
        // GET: Project
        //affichage
        public ActionResult Index(string searchString)
        {
            var projects = new List<ProjectVM>();
            foreach (Project p in MyProjectService.SearchProjectByName(searchString))
            {
                projects.Add(new ProjectVM()
                {
                    ProjectId = p.ProjectId,
                    Name = p.Name,
                    Description = p.Description,
                    Category = (CategoryVM)p.Category,
                    Image = p.Image,
                    Progress = p.Progress,
                    TeamId = (int)p.TeamId,
                    //Tache

                    



                });
            }
     
            return View(projects);
        }

        //GET: Project/Details/5
        public ActionResult Details(int id)
        {
            Project p = MyProjectService.GetById(id);
            ProjectVM PVM = new ProjectVM()
            {

                ProjectId = p.ProjectId,
                Name = p.Name,
                Description = p.Description,
                TeamId = (int)p.TeamId,
                tasks = p.tasks,
                Progress = p.Progress

            };

            return View(PVM);

        }
        public ActionResult Email(string receiverEmail, string subject, string message)
        {
            MyProjectService.SendEmail(receiverEmail, subject, message);
            return View();
}

        // GET: Project/Create
        public ActionResult Create()
        {
            var mytypes = MyTeamService.GetMany();
            ViewBag.Teams = new SelectList(mytypes, "TeamId", "name");
            return View();
        }

        //POST: Project/Create
       //ajout base
        [HttpPost]
        public ActionResult Create(ProjectVM ProjectVM, HttpPostedFileBase Image)
        {
            Project ProjectDomain = new Project()
            {
                Description = ProjectVM.Description,
                Category = (Category)ProjectVM.Category,
                Image = Image.FileName,
                Name = ProjectVM.Name,
                TeamId=ProjectVM.TeamId
                

            };
            MyProjectService.Add(ProjectDomain);
            MyProjectService.Commit();
            //ajout de l'image dans un dossier Upload
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");

            //MailMessage mail = new MailMessage("rabebdina.abid@esprit.tn", "r.dinaabid@gmail.com", "Projet pret", "votre projet est maitenant assigné a un groupe d'ing");
            //// MailMessage mail = new MailMessage();
            //mail.IsBodyHtml = true;
            //SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
            //smtpClient.EnableSsl = true;

            //smtpClient.Credentials = new System.Net.NetworkCredential("rabebdina.abid@esprit.tn", "dina123");
            //smtpClient.Send(mail);



        }

        //GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            Project p = MyProjectService.GetById(id);
            ProjectVM pm = new ProjectVM();

            pm.ProjectId = p.ProjectId;
            pm.Name = p.Name;
            //ImageUrl = Image.FileName,
            pm.Description = p.Description;
            pm.Category =(CategoryVM)p.Category;
            pm.Progress = p.Progress;
            pm.tasks = p.tasks;

           
            return View(pm);
            
        }

        //POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProjectVM pm /*, HttpPostedFileBase Image */)
        {

                try
                {

                    Project p = MyProjectService.GetById(id);
                    p.Name = pm.Name;
                    p.Description = pm.Description;
                    //ImageUrl = Image.FileName,
                    p.Category = (Category)pm.Category;
                    p.Progress = pm.Progress;

                    // var path = Path.Combine(Server.MapPath("~/Content/Uploads"), Image.FileName);
                    //Image.SaveAs(path);
                    MyProjectService.Update(p);
                    MyProjectService.Commit();
                    // TODO: Add update logic here
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(pm);
                }
            }

        // GET: Publication/Delete/5
        public ActionResult Delete(int id)
        {
            Project p = MyProjectService.GetById(id);
            ProjectVM pm = new ProjectVM()
            {

                ProjectId = p.ProjectId,
                Name = p.Name,
                Description = p.Description,
                TeamId = (int)p.TeamId,
                tasks = p.tasks,
                Progress = p.Progress

            };
            return View(pm);

        }

        // POST: Publication/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Project p = MyProjectService.GetById(id);
            MyProjectService.Delete(p);
            MyProjectService.Commit();
            // TODO: Add delete logic here

            return RedirectToAction("Index");

        }

        


    }





    }

