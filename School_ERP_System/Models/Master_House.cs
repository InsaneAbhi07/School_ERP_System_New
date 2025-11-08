using System.ComponentModel.DataAnnotations;

namespace School_ErP.Models
{
    public class Master_House
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="House is required to input")]
        public string House { get; set; }
    }
}
