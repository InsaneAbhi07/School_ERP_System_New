using System.ComponentModel.DataAnnotations;

namespace School_ErP.Models
{
    public class FeeDeposite
    {
        [Key]
        public int Id { get; set; }

        public string Location { get; set; }

        public DateOnly EntryDate { get; set; }

        public string EntryCDate { get; set; }

        public string Session { get; set; }
        public string AdmnNo { get; set; }

        public string ReceiptNo { get; set; }

        public string Cancel { get; set; }

        public string Regno { get; set; } 

        public string Mon { get; set; }

        public string Month { get; set; }
        public string MonthTo { get; set; }

        public string FeeHead { get; set; }

        public decimal Amount { get; set; } 

        public decimal Late { get; set; }

        public decimal Concession { get; set; }

        public decimal Total { get; set; }

        public string PayMode { get; set; }    

        public int CashAmt { get; set; }    

        public int ChequeAmt { get; set; }

        public string ChequeNo { get; set; }

        public string ChequeDate { get; set; }
        public string ChequeBank{ get; set; }
        public string Bank { get; set; }  

        public string Remark { get; set; }

        public string User { get; set; }

        public int Sid { get; set; }

        public int NetFee { get; set; }  

        public string CBounce { get; set; } 

        public string CBounceDate { get; set; } 

    }
}
