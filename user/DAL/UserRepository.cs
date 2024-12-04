using DAL.Helper;

namespace DAL
{
    public partial class UserRepository : IUserRepository
    {
        private IDatabaseHelper _databaseHelper;
        public UserRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public bool Add(User user )
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarProcedure(out msgError, "user_add",
                    "@userid", user.UserId,
                    "@username", user.UserName,
                    "@password", user.Password,
                    "@roleid", user.RoleId,
                    "@name", user.Name,
                    "@email", user.Email,
                    "@phone", user.Phone,
                    "@imgurl", user.ImgUrl,
                    "@address", user.Address,
                    "@dateofbirth", user.DateOfBirth);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}