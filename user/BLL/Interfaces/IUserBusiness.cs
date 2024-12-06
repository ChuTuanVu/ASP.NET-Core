namespace BLL
{
    public partial interface IUserBusiness
    {
        User Authentication(string username, string password);
        bool Add(User user);

        bool Update(User user);
        bool Delete(string userid);
    }
}
