using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terabyte.Domain.Entities;
using Terabyte.Service;
using Terabyte.Web.Models;

namespace Terabyte.Web.Controllers
{
    public class EventController : Controller
    {

        IEventService MyEventService;
        public EventController()
        {
          

            MyEventService = new EventService();
        }

        // GET: Event
        
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()
        {

            var events = MyEventService.GetMany();
            

            
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
  
        }

        [HttpPost]
        public JsonResult SaveEvent(EventVM e)
        {
            var status = false;
            
            
                if (e.EventID > 0)
                {
                    //Update the event
                    Event v = MyEventService.GetById(e.EventID);
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = (DateTime)e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    MyEventService.Update(v);
                    }
                }
                else
                {
                Event v = new Event() {
                Description=e.Description,
                End=e.End,
                IsFullDay=e.IsFullDay,
                Start=(DateTime)e.Start,
                Subject=e.Subject,
                ThemeColor=e.ThemeColor
                
                };
                MyEventService.Add(v);
                }

            MyEventService.Commit();
                status = true;

            
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
           
                var v = MyEventService.GetById(eventID);
                if (v != null)
                {
                MyEventService.Delete(v);
                MyEventService.Commit();
                    status = true;
                }
            
            return new JsonResult { Data = new { status = status } };
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
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

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
