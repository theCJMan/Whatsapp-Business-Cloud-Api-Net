
namespace SharedLibrary
{
    public interface ISqlDataAccess
    {
        Task<List<T>> ExecSP_RetData<T>(string storedProc, string connectionName, object? paramseters);
        Task ExecSP_RetNoData(string storedProc, string connectionName, object paramseters);
        Task<T> ExecSP_RetSingleValue<T>(string storedProc, string connectionName, object paramseters);
    }
}