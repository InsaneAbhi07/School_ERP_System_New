using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using School_ErP.Models;

namespace School_ERP_System.Models
{
    public class FeeDepositeDetail
    {
        [Key]
        public int Id { get; set; }

        public int FeeDepositeId { get; set; }

        public string Month { get; set; }
        public string Installment { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("FeeDepositeId")]
        public FeeDeposite FeeDeposite { get; set; }
    }
}
