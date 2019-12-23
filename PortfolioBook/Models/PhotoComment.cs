using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PortfolioBook.Models
{
    public class PhotoComment
    {
        public int PhotoCommentID { get; set; }
        public string ApplicationUserID { get; set; }
        [ForeignKey("Photo")]
        public int PhotoID { get; set; }
        [MaxLength(400)]
        public string PhotoCommentText { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Photo Photo { get; set; }//bir projenin bir çok commendi olabilir//
    }
}