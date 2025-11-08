using System.ComponentModel.DataAnnotations;

namespace School_ErP.Models
{
    public class Master_Classes
    {
        [Key]
        public int Id { get; set; }
        public string ?Class{ get; set; }

        public string ?Wing { get; set; }
    }
}
