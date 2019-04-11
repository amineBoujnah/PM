using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum Category
{
    other

}
namespace Terabyte.Domain.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Category category { get; set; }
        public int progress { get; set; }
        public virtual ICollection<Team> teams { get; set; }
        public virtual ICollection<Task> tasks { get; set; }
    }
}
