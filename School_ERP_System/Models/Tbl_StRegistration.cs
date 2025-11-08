using System.ComponentModel.DataAnnotations;

namespace School_ErP.Models
{
    public class Tbl_StRegistration
    {

        [Key]
        public int Id { get; set; }

        // Basic Info
        [Required(ErrorMessage ="Form No. is required")]
        public string FormNo { get; set; }
        [Required(ErrorMessage = "Reg No. is required")]
        public string RegNo { get; set; }
        [Required(ErrorMessage = "Roll No. is required")]
        public string RollNo { get; set; }
        [Required(ErrorMessage = "Addmission Date is required")]
        public DateTime? AdmDate { get; set; }
        public string ?APAARID { get; set; }
        [Required(ErrorMessage = "Addmission in Class is required")]
        public string AdmInClass { get; set; }
        [Required(ErrorMessage = "Current Class is required")]
        public string CurrentClass { get; set; }
        public string ?Section { get; set; }
        public string ?House { get; set; }
        public string ?Stream { get; set; }

        // Personal Info
        [Required(ErrorMessage = "Student Name is required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateOnly? DateOfBirth { get; set; }
        public string ?DOBInWords { get; set; }
        public string ?Gender { get; set; }
        public string ?MotherName { get; set; }
        public string ?MotherQualification { get; set; }
       public string ?MotherOccupation { get; set; }
        public decimal? MotherIncome { get; set; }
        public string ?FatherName { get; set; }
            public string ?FatherQualification { get; set; }
       public string ?FatherOccupation { get; set; }
        public decimal? FatherIncome { get; set; }
        public string ?GuardianName { get; set; }
        public string ?GuardianRelation { get; set; }
        public string ?Nationality { get; set; }
        public string ?Religion { get; set; }
        public string ?CasteCategory { get; set; }
        public string ?AadharNo { get; set; }

        // Address Info
        public string ?PermAddress { get; set; }
        public string ?PermState { get; set; }
        public string ?PermCity { get; set; }
       public string ?PermPIN { get; set; }
      public string ?PermPhone { get; set; }
       public string ?PermMobile { get; set; }

        public bool IsCorrAddressSameAsPerm { get; set; }
        public string ?CorrAddress { get; set; }
        public string ?CorrState { get; set; }
        public string ?CorrCity { get; set; }
        public string ?CorrPIN { get; set; }
        public string ?CorrPhone { get; set; }
        public string ?CorrMobile { get; set; }

        // Previous Academic
        public string ?AcademicYear { get; set; }
        public string ?SchoolName { get; set; }
        public string ?PreviousClass { get; set; }
        public string ?Result { get; set; }

        // Fee
        public string ?FeeCategory { get; set; }
        public string ?SpecialCase { get; set; }
        public string ?StudentQuota { get; set; }
        public string ?SMSNo { get; set; }

        // Flags
        public bool? AdmissionCancelled { get; set; }
        public bool? NotShow { get; set; }

        // Image Paths
        public string ?StudentPhoto { get; set; }
        public string ?FatherPhoto { get; set; }
        public string ?MotherPhoto { get; set; }
    }

}
