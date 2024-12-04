namespace Models
{
    public class Item
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Category Category { get; set; }
        public List<BillDetail> BillDetails { get; set; }
    }
}
