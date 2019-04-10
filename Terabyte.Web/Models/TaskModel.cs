using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Terabyte.Web.Models
{
    public enum StateVM
    {
        To_Do,
        Doing,
        Done

    }
    public enum ComplexityVM
    {
        Low,
        Medium,
        Hight
    }
    public class TaskModel
    {
        public int TaskId { get; set; }
        public String name { get; set; }
        public String ImageUrl { get; set; }
        [DataType(DataType.Date)]
        public DateTime start_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime end_date { get; set; }
        public StateVM state { get; set; }
        public ComplexityVM complexity { get; set; }
        public int priority { get; set; }
        public int progress { get; set; }
        [Display(Name = "User")]
        public int? UserId { get; set; }
        [Display(Name = "Projet")]
        public int? ProjectId { get; set; }


    }
}