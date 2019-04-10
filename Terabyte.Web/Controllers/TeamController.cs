using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class TeamController : Controller
    {
       ITeamService  MyTeamService;

        //   private ApplicationDbContext db = new ApplicationDbContext();
        public TeamController()
        {
            MyTeamService = new TeamService();

        }

        // GET: Team
        public ActionResult Index()
        {
            var teams = new List<TeamsVM>();
            foreach (Team t in MyTeamService.GetMany())
            {
                teams.Add(new TeamsVM()
                {
                    name = t.name,
                  //  specialty = (SpecialtyVM)t.specialty,
                    image = t.image,
                    TeamId=t.TeamId


                });
            }
                return View(teams);
        }

        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            Team t = MyTeamService.GetById(id);
            TeamsVM TVM = new TeamsVM()
            {

                
                name = t.name

            };
            return View(TVM);
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            var MyTeams = MyTeamService.GetMany();
            ViewBag.ListTasks = new SelectList(MyTeams, "name");
            return View();
            
        }

        // POST: Team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamsVM TeamsVM, HttpPostedFileBase image)
        {
            Team TeamDomain = new Team()
            {
               
                image = image.FileName,
                name = TeamsVM.name,
               

            };
            MyTeamService.Add(TeamDomain);
            MyTeamService.Commit();
            //ajout de l'image dans un dossier Upload
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), image.FileName);
            image.SaveAs(path);
            return RedirectToAction("Index");

            
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            Team t = MyTeamService.GetById(id);
            TeamsVM tm = new TeamsVM();


            tm.name = t.name; 
           // ImageUrl = Image.FileName
           
            return View(tm);
         
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeamsVM tm )
        {
            try
            {

                Team t = MyTeamService.GetById(id);
                t.name = tm.name;
               
                MyTeamService.Update(t);
                MyTeamService.Commit();
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(tm);
            }
            
        }

        // GET: Team/Delete/5
        public ActionResult Delete(int? id)
        {
           
            return View();
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            Team t = MyTeamService.GetById(id);
            MyTeamService.Delete(t);
            MyTeamService.Commit();
            // TODO: Add delete logic here

            

            return RedirectToAction("Index");
        }

        
    }
}
