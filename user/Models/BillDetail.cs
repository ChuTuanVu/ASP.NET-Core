namespace Models
{
    public class BillDetail
    {
        public string BillDetailId { get; set; }
        public string BillId { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? SubTotal { get; set; }
        public string StaffId { get; set; }
        public Bill Bill { get; set; }
        public Staff Staff { get; set; }
        public Item Item { get; set; }
    }
}
