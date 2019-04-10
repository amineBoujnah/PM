using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Terabyte.Domain.Entities;

namespace Terabyte.Web.Models
{
    public partial class CommentVM
    {
        public int CommentId { get; set; }
        public string Contenu { get; set; }
        public int? PublicationId { get; set; }
       
        public virtual Publication publication { get; set; }
    }
}