using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
public enum VisibilityVM
{
    Public,
    Private

}
namespace Terabyte.Web.Models
{
    public class PublicationVM
    {
        public int PublicationId { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public VisibilityVM visibility { get; set; }

        public DateTime? creationDate { get; set; }

       // public int? OwnerId { get; set; }
    }
}