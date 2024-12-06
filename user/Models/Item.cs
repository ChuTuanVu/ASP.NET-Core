namespace Models
{
    public class Item
    {
        public string itemid { get; set; }
        public string itemname { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public string categoryid { get; set; }
        public DateTime createdtime { get; set; }
        public DateTime? updatedtime { get; set; }
    }
}
