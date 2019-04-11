using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terabyte.Domain.Entities;

namespace Terabyte.Service
{
   public interface ITaskService:IService<Task>
    {
        IEnumerable<Task> SearchTasksByName(string searchString);
    }
}
