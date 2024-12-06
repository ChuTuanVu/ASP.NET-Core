using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public partial class UserBusiness : IUserBusiness
    {
        private IUserRepository _userRepository;
        private string Secret;
        public UserBusiness(IUserRepository userRepository, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _userRepository = userRepository;
        }
        public bool Add(User user)
        {
            return _userRepository.Add(user);
        }

        public bool Update(User user)
        {
            return _userRepository.Update(user);
        }

        public bool Delete(string userid) 
        { 
            return _userRepository.Delete(userid); 
        }
        public User Authentication(string username, string password)
        {
            var user = _userRepository.GetUser(username, password);
            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, user.username.ToString()),
                    new(ClaimTypes.StreetAddress, user.userid) //config lai
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}