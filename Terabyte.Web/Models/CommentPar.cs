namespace Terabyte.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommentPar
    {
        [Key]
        public int CommentId { get; set; }

        public string Contenu { get; set; }

        public int? PublicationId { get; set; }
    }
}
