using System;
using Ulaw.ApplicationProcessor.Enums;

namespace Ulaw.ApplicationProcessor.Models
{
    public class ApplicationModel
    {
        public Guid ApplicationId { get; set; }
        public string Faculty { get; set; }
        public string CourseCode { get; set; }
        public DateTime StartDate { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool RequiresVisa { get; set; }
        public DegreeGradeEnum DegreeGrade { get; set; }
        public DegreeSubjectEnum DegreeSubject { get; set; }
    }
}
