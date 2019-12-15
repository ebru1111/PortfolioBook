using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PortfolioBook.Models
{
    public class ProjectStar
    {
        [Key]
        public int ProjectStarID { get; set; }
        public string ApplicationUserID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Project Project { get; set; }
        public float? Star { get; set; }//yıldız alır yada almaz

    }
}