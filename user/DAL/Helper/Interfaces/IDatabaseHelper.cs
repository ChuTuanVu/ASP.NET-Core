using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL.Helper
{
    public class ProcedureParameter
    {
        public string ProcedureName { get; set; }
        public List<Object> ProcedureParams { get; set; }
    }

    public interface IDatabaseHelper
    {
        void SetConnectionString(string connectionString);
        string OpenConnection();
        string CloseConnection();
        string ExecuteNonQuery(string strquery);
        object ExecuteScalar(string strquery, out string msgError);
        string ExecuteProcedure(string sprocedureName, params object[] paramObjects);
        DataTable ExecuteQueryToDataTable(string strquery, out string msgError);
        DataTable ExecuteProcedureReturnDataTable(out string msgError, string sprocedureName, params object[] paramObjects);
        DataSet ExecuteProcedureReturnDataset(out string msgError, string sprocedureName, params object[] paramObjects);
        string ExecuteProcedure(SqlConnection sqlConnection, string sprocedureName, params object[] paramObjects);
        List<string> ExecuteScalarProcedure(List<ProcedureParameter> storeParameterInfos);
        object ExecuteScalarProcedure(out string msgError, string sprocedureName, params object[] paramObjects);
        List<object> ExecuteScalarProcedure(out List<string> msgErrors, List<ProcedureParameter> storeParameterInfos);
        List<Object> ReturnValuesFromExecuteProcedure(out string msgError, string sprocedureName, int outputParamCountNumber, params object[] paramObjects);
    }
}
