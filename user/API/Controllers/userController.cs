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
        public User addUser ([FromBody] User user)
        {
            user.userid = Guid.NewGuid().ToString();
            _userBusiness.Add(user);
            return user;
        }

        [Route("user-update")]
        [HttpPost]
        public User updateUser([FromBody] User user) { 
            _userBusiness.Update(user);
            return user;
        }

        [Route("user-delete")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string userid = string.Empty;
            if (formData.Keys.Contains("userid") && !string.IsNullOrEmpty(Convert.ToString(formData["userid"]))) { userid = Convert.ToString(formData["userid"]); }
            _userBusiness.Delete(userid);
            return Ok();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Authenticate authenticate) {

            var user = _userBusiness.Authentication(authenticate.username, authenticate.password);
            if (user == null)
                return BadRequest(new { message = "Tên người dùng hoặc mật khẩu không chính xác!" });
            return Ok(new { userid = user.userid, username = user.username, token = user.token });
        }
    }
}