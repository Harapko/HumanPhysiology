using Npgsql;

namespace HumPsi.Infrastructure.Factory;

public class SqlConnFactory : ISqlConnFactory
{
    public NpgsqlConnection GetConnection()
    {
        throw new NotImplementedException();
    }
}