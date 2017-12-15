using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelapp.services.Data
{
    public interface IDataProvider
    {

        void ExecuteCmd(
            string storedProc,
            Action<SqlParameterCollection> inputParamMapper,
            Action<IDataReader, short> singleRecordMapper,

            Action<SqlParameterCollection> returnParameters = null,
            Action<SqlCommand> cmdModifier = null);
        int ExecuteNonQuery(string storedProc,
            Action<System.Data.SqlClient.SqlParameterCollection> inputParamMapper,
            Action<System.Data.SqlClient.SqlParameterCollection> returnParameters = null);

    }
}
