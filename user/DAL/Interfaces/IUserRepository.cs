namespace DAL
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
        bool Add(User user);
        bool Update(User user);
        bool Delete(string userid);
    }
}