using DAL;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public partial class UserBusiness : IUserBusiness
    {
        private IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
        }
        public bool Add(User user  )
        {
            return _userRepository.Add(user );
        }
    }
}
