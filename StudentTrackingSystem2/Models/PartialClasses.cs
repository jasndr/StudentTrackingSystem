using System;
using System.ComponentModel.DataAnnotations;


namespace StudentTrackingSystem2.Models
{
    [MetadataType(typeof(StudentMetadata))]
    public partial class Graduate_Student
    {
    }

    [MetadataType(typeof(CourseworkMetaData))]
    public partial class Graduate_Coursework
    {
    }
}