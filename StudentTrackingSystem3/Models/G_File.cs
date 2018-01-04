using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class G_File
    {
        public int G_FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public G_FileType FileType { get; set; }
        public Nullable<int> ManuscriptID { get; set; }
        public Nullable<int> ActivityID { get; set; }
        public Nullable<int> CurriculumVitaeID { get; set; }
       
        public virtual G_Manuscript Manuscript { get; set; }
        public virtual G_Activity Activity { get; set; }
        public virtual G_CurriculumVitae CurriculumVitae { get; set; }
    }
}