using System.ComponentModel.DataAnnotations;

namespace School_ErP.Models
{
    public class Master_School
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "School Code")]
        public string SCode { get; set; }
        [Display(Name ="School Name")]
        public string SName { get; set; }

        public string Address { get; set; }    
        public string ?City { get; set; }

        public string ?State { get; set; }
        [Display(Name = "Pincode")]
        public string ?PinCode { get; set; }
        public string ?Phone { get; set; }
        public string ?Email { get; set; }
        [Display(Name = "Website")]
        public string ?Web { get; set; }
        [Display(Name = "Affilation No.")]
        public string ?AffNo { get; set; }
        public byte[]? Photo { get; set; }
        [Display(Name = "School Status")]
        public string ?Active { get; set; }

    }
}
