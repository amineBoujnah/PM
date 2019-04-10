using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Terabyte.Domain.Entities;
using Terabyte.Service;
using Terabyte.Web.Models;

namespace Terabyte.Web.Controllers
{
    public class TaskWebApiController : ApiController
    {
        ITaskService MyService = null;

        private TaskService ts = new TaskService();
        List<TaskModel> tach = new List<TaskModel>();
        public TaskWebApiController()
        {
            MyService = new TaskService();
            Index();
            tach = Index().ToList();
        }

        public List<TaskModel> Index()
        {
            List<Tache> gache = ts.geTache();
            List<TaskModel> tacheXml = new List<TaskModel>();
            foreach (Tache t in gache)
            {
                tacheXml.Add(new TaskModel
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
                });
            }
            return tacheXml;
        }
        //Get: api/RecWebApi
        public IEnumerable<TaskModel> Get()
        {
            return tach;
        }
        //Get: api/RecWebApi/5

        public string Get(int id)
        {
            return "value";
        }
        //POST: api/RecWebApi
        public void Post([FromBody]string value)
        {

        }
        

        //PUT: api/RecWebApi
        public void Put (int id, [FromBody]string value)
        {

        }

        //DELETE: api/RecWebApi/5
        public IHttpActionResult Delete (int id)
        {
            Tache th = MyService.GetById(id);
            MyService.Delete(th);
            MyService.Commit();
            return Ok(th);
        }
    }
}
