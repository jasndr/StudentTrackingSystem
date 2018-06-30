using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentTrackingSystem3.Models
{
    public class File
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public Nullable<int> ManuscriptId { get; set; }
        public Nullable<int> ActivityId { get; set; }
        public Nullable<int> CurriculumVitaeId { get; set; }
       
        public virtual Manuscript Manuscript { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual CurriculumVitae CurriculumVitae { get; set; }
    }
}