using System.ComponentModel.DataAnnotations;

namespace School_ErP.Models
{
    public class Master_Section
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Section properly.")]
         public string Sec { get; set; }
    }
}
