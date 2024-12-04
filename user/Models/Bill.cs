namespace Models
{
    public class Bill
    {
        public string BillId { get; set; }
        public string UserId { get; set; }
        public DateTime? BillDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<BillDetail> BillDetails { get; set; }
    }
}