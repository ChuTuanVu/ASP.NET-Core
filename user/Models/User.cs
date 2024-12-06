using System.Text.Json.Serialization;

public class User
{
    [JsonIgnore]
    public string userid { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    [JsonIgnore]
    public int roleid { get; set; } = 1;
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string imgurl { get; set; }
    public string address { get; set; }
    public DateTime? dateofbirth { get; set; }
    [JsonIgnore]
    public string token { get; set; }
}
public class UserUpdate : User
{
    public new string userid { get; set; }
    [JsonIgnore]
    public new string username { get; set; }
}
