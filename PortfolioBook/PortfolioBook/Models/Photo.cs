using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PortfolioBook.Models
{
    public class Photo
    {
        [Key]
        public int PhotoID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }//bir projenin birçok photosu olur 
        public virtual List<PhotoComment> PhotoComments { get; set; }//bir projenin birçok commendi vardır

        [Required, MaxLength(500)]
        public string ImageUrl { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime AddedDate { get; set; }//eklenmeTarihi

        [Required(ErrorMessage = "Bu alan zorunludur."),MaxLength(300)]
        public string AltText { get; set; }


    }
}