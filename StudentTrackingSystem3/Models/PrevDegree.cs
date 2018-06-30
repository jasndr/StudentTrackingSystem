using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class PrevDegree
    {
        public int Id { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required(ErrorMessage ="You must enter a degree type"), Display(Name ="Degree Type")]
        public int DegreeTypesID { get; set; }
        [Display(Name="Degree Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You must enter your Cumulative GPA for this degree."), Display(Name ="Cumulative GPA"), Range(0.00, 4.00, ErrorMessage ="GPA must range from 0.00 to 4.00")]
        public decimal CumulativeGPA { get; set; }
        [Required(ErrorMessage = "You must enter the school name for this degree"), Display(Name ="School Name")]
        public string SchoolName { get; set; }
        [Required]
        public string Major { get; set; }
        [Display(Name ="Second Major")]
        public string SecondMajor { get; set; }
        public string Minor { get; set; }
        [Required(ErrorMessage = "You must enter the expected or awarded date of this degree."), Display(Name = "Date Awarded / To Be Awarded")]
        public System.DateTime DateOfAward { get; set; }

        public virtual Student Student { get; set; }
        public virtual CommonFields DegreeTypes { get; set; }

    }
}