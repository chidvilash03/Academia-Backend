using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities
{
    public class Student
    {
        [Key]
        public int EnrollmentNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly AdmissionDate { get; set; }

        //public Photo - Doubt - link Format ?

        //Foreign Key to Class
        public int ClassId { get; set; }
        //public Class Class { get; set; }

        //Foreign key to Section
        public int SectionId { get; set; }
        //public Section Section { get; set; }

        public string MotherTongue { get; set; }
        public string Religion { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Village { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Mobile { get; set; }
        public string AadharNumber { get; set; }

        //Foreign key to Parent
        public int ParentId { get; set; }
        public Parent Parent { get; set; }

        //Foreign key to Guardian
        public int GuardianId { get; set; }
        public Guardian Guardian { get; set; }

        //Foreign key to Hosteler
        public int HostelerId { get; set; }
        public Hosteler Hosteler { get; set; }

        public bool IsActive { get; set; }


    }
}
