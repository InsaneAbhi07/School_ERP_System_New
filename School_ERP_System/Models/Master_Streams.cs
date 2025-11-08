using System.ComponentModel.DataAnnotations;

namespace School_ErP.Models
{
    public class Master_Streams
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Stream required to input.")]
        public string Stream{ get; set; }
    }

}
