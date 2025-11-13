public class FeeReceiptSummaryVM
{
    public int Id { get; set; }
    public string ReceiptNo { get; set; }
    public DateOnly EntryDate { get; set; }
    public string Regno { get; set; }
    public string PayMode { get; set; }
    public decimal Amount { get; set; }
    public string Remark { get; set; }
    public string User { get; set; }
}
