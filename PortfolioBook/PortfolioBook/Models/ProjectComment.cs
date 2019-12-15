using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PortfolioBook.Models
{
    public class ProjectComment
    {//yorum tarihi eklensin mi?
        [Key]
        public int ProjectCommentID { get; set; }
        public string ApplicationUserID { get; set; }

        [ForeignKey("Project")]
        public int ProjectID { get; set; }

        [MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string ProjectCommentText { get; set; }
        public bool? IsLike { get; set; }//like alır yada almaz

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Project Project { get; set; }

    }
}