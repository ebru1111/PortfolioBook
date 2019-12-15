using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PortfolioBook.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string ApplicationUserID { get; set; }

        [Column(TypeName ="datetime2"),DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RealeseDate { get; set; }//Yayınlanmatarihi
        public int? NumberOfPageViews { get; set; }//görüntülenme sayısı
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual List<Photo> Photos { get; set; }//bir projenin birçok fotoğrafı vardır//çok kısmı
        public virtual List<ProjectStar> ProjectStars { get; set; }//bir projenin birçok fotoğrafı vardır//çok kısmı
        public virtual List<ProjectComment> ProjectComments { get; set; }//bir projenin birçok commendi vardır//çok kısmı
    }
}