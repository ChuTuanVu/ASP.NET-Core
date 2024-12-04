public class User
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; } = 1;
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string ImgUrl { get; set; }
    public string Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Token { get; set; }
}