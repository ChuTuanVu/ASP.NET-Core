using DAL.Helper;
using System.Data;
using System.Reflection;

namespace DAL
{
    public partial class UserRepository : IUserRepository
    {
        private IDatabaseHelper _databaseHelper;
        public UserRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public User GetUser(string u, string p)
        {
            string msgError = string.Empty;
            try
            {
                var dt = _databaseHelper.ExecuteProcedureReturnDataTable(out msgError, "user_get_by_username_password", "@username", u, "@password", p);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<User>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Add(User user )
        {
            string msgError = "";
            try
            {
                var result = _databaseHelper.ExecuteScalarProcedure(out msgError, "user_add",
                    "@userid", user.userid,
                    "@username", user.username,
                    "@password", user.password,
                    "@roleid", user.roleid,
                    "@name", user.name,
                    "@email", user.email,
                    "@phone", user.phone,
                    "@imgurl", user.imgurl,
                    "@address", user.address,
                    "@dateofbirth", user.dateofbirth);

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
        public bool Update(User user)
        {
            string msgError = string.Empty;
            try
            {
                var result = _databaseHelper.ExecuteScalarProcedure(out msgError, "user_update",
                    "@userid", user.userid,
                    "@password", user.password,
                    "@name", user.name,
                    "@email", user.email,
                    "@phone", user.phone,
                    "@imgurl", user.imgurl,
                    "@address", user.address,
                    "@dateofbirth", user.dateofbirth);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(string userid)
        {
            string msgError = string.Empty;
            try
            {
                var result = _databaseHelper.ExecuteScalarProcedure(out msgError, "user_delete",
                "@userid", userid);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}