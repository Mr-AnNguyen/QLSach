using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Connect
{
    public class StoreParameterInfo
    {
        public string StoreProcedureName { get; set; }
        public List<Object> StoreProcedureParams { get; set; }
    }
    public partial interface IDBContext
    {
        DataTable ExecuteSProcedureReturnDataTable(out string msgError, string sprocedureName, params object[] paramObjects);
        List<object> ExecuteScalarSProcedureWithTransaction(out List<string> msgErrors, List<StoreParameterInfo> storeParameterInfos);

        object ExecuteScalarSProcedureWithTransaction(out string msgError, string sprocedureName, params object[] paramObjects);
    }
}
