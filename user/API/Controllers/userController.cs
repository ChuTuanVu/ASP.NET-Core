using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{

    public class userController : Controller
    {
        private IUserBusiness _userBusiness;
        public userController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [Route("user-add")]
        [HttpPost]
        public User user ([FromBody] User user)
        {
            user.UserId = Guid.NewGuid().ToString();
            _userBusiness.Add(user);
            return user;
        }
    }
}