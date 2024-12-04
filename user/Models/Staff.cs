namespace Models
{
    public class Staff
    {
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<BillDetail> BillDetails { get; set; }
    }
}
