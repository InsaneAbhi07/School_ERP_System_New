using System.ComponentModel.DataAnnotations;

namespace School_ErP.Models
{
    public class Master_MonthFee
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Input is required")]
        public  string CurClass { get; set; }

        public int Mon { get; set; }
        public string Month { get; set; }
        public string fee { get; set; }
        public decimal Amount { get; set; }

        public string Mode { get; set; }
        public string Session { get; set; }
        
        public int Sid { get; set; }
    }
}
