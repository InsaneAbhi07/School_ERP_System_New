using System.ComponentModel.DataAnnotations;

namespace School_ErP.Models
{
    public class OldBalance
    {
        [Key]
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Reg No. is reuired")]
        public string RegNo { get; set; }
        [Required(ErrorMessage = "Balance Amount is reuired")]
        public decimal BalanceAmount { get; set; }
        public DateOnly EDate { get; set; }
        public string ?Session { get; set; }
        public string B_Session { get; set; }
        public int DFlag { get; set; }  
        public string Remark { get; set; }

    }
}
