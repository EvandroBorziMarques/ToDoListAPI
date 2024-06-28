using Dapper;

namespace Domain.Interface
{
    public interface IBaseRepository
    {
        T QueryFirst<T>(string procedure, DynamicParameters parameters);
        List<T> Query<T>(string procedure, DynamicParameters parameters);
        bool Execute(string procedure, DynamicParameters parameters);
    }
}
