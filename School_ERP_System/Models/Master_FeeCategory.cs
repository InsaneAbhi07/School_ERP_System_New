using System.ComponentModel.DataAnnotations;

namespace School_ErP.Models
{
    public class Master_FeeCategory
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Required to input.")]
        public string Location  { get; set; }
    }
}
