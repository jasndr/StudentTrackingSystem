using System;
using System.ComponentModel.DataAnnotations;


namespace StudentTrackingSystem2.Models
{
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
    }

    [MetadataType(typeof(CourseworkMetaData))]
    public partial class Coursework
    {
    }
}