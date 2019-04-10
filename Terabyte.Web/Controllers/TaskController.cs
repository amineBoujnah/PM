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
    public class TaskController : Controller
    {
        ITaskService MyTaskService;
        public TaskController()
        {
            MyTaskService = new TaskService();
        }

        TaskService MyTaskServiceee = new TaskService();


        // GET: Tache
        public ActionResult Index(string searchString)
        {
            var Tasks = new List<TaskModel>();
            foreach (Tache t in MyTaskService.SearchTasksByName(searchString))
            {
                TaskModel tss = new TaskModel()
                {
                    TaskId = t.TaskId,
                    name = t.name,
                    ImageUrl = t.ImageUrl,
                    start_date = t.start_date,
                    end_date = t.end_date,
                    state = (StateVM)t.state,
                    complexity = (ComplexityVM)t.complexity,
                    priority = t.priority,
                    progress = t.progress,
                    ProjectId=t.ProjectId
                };
                Tasks.Add(tss);
                ViewBag.SS = tss.state;
            }
            // Partie designe 


            //string color = "red";
            //ViewBag.color = color;


            //###################

            return View(Tasks);
        }

        // GET: Tache/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tache t;
            t = MyTaskService.GetById((int)id);
            if (t == null)
            {
                return HttpNotFound();
            }
            TaskModel tvm = new TaskModel()
            {
                TaskId = t.TaskId,
                name = t.name,
                ImageUrl = t.ImageUrl,
                start_date = t.start_date,
                end_date = t.end_date,
                state = (StateVM)t.state,
                complexity = (ComplexityVM)t.complexity,
                priority = t.priority,
                progress = t.progress
            };
            return View(tvm);
        }

        // GET: Tache/Create
        public ActionResult Create()
        {
            // var MyTasks = MyTaskService.GetMany();
            // ViewBag.ListTasks = new SelectList(MyTasks, "name");
            //viewbag :variable pour tronsporter les données du controller lil vue 
            return View();
        }

        // POST: Tache/Create
        [HttpPost]
        public ActionResult Create(int  ProjectId ,TaskModel tm, HttpPostedFileBase Image)
        {
            Tache td = new Tache();
            // TaskModel tm = new TaskModel();
            td.ProjectId = ProjectId;
            td.name = tm.name;
            td.ImageUrl = Image.FileName;
            td.start_date = DateTime.UtcNow;
            td.end_date = tm.end_date;
            td.state = (State)tm.state;
            td.complexity = (Complexity)tm.complexity;
            td.priority = tm.priority;
            td.progress = tm.progress;

            MyTaskService.Add(td);
            MyTaskService.Commit();

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");
        }

        // GET: Tache/Edit/5
        public ActionResult Edit(int id)
        {
            Tache t = MyTaskService.GetById(id);
            TaskModel tm = new TaskModel();

            tm.name = t.name;
            //ImageUrl = Image.FileName,
            tm.start_date = t.start_date;
            tm.end_date = t.end_date;
            tm.state = (StateVM)t.state;
            tm.complexity = (ComplexityVM)t.complexity;
            tm.priority = t.priority;
            tm.progress = t.progress;
            return View(tm);
        }

        // POST: Tache/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel tm, HttpPostedFileBase Image)
        {
            try
            {
                Tache t = MyTaskService.GetById(id);
                t.name = tm.name;
                //ImageUrl = Image.FileName,
                t.start_date = tm.start_date;
                t.end_date = tm.end_date;
                t.state = (State)tm.state;
                t.complexity = (Complexity)tm.complexity;
                t.priority = tm.priority;
                t.progress = tm.progress;
                // var path = Path.Combine(Server.MapPath("~/Content/Uploads"), Image.FileName);
                //Image.SaveAs(path);
                MyTaskService.Update(t);
                MyTaskService.Commit();
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(tm);
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tache/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Tache t = MyTaskService.GetById(id);
            MyTaskService.Delete(t);
            MyTaskService.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult stat()
        {
            var list = MyTaskServiceee.GetMany();
            List<int> repartition = new List<int>();
            var states = list.Select(x => x.state).Distinct();
            foreach (var item in states)
            {
                repartition.Add(list.Count(x => x.state == item));
            }
            var rep = repartition;
            ViewBag.type = states;
            ViewBag.REP = repartition.ToList();

         
            return View();
        }



        public ActionResult statistique()
        {
            var list = MyTaskServiceee.GetMany();
            List<int> repartition = new List<int>();
            var states = list.Select(x => x.state).Distinct();
            foreach (var item in states)
            {

                repartition.Add(list.Count(x => x.state == item));
            }
            var rep = repartition;
            ViewBag.type = states;
            ViewBag.REP = repartition.ToList();


            return View();
        }
    }
}