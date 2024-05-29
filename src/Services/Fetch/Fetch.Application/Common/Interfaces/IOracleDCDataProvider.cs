using System.Data;
using Devart.Data.Oracle;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;

public interface IOracleDCDataProvider
{
    void Close();
    OracleTransaction BeginTransaction();
    IDataReader GetReader(OracleCommand qry);
    OracleDataSet GetDataSet(OracleCommand qry);
    object ExecuteScalar(OracleCommand poQuery);
    public int ExecuteQuery(OracleCommand poQuery);
    Task<List<string>> GetColumnNamesAsync();
}
