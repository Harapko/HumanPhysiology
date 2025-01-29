using Npgsql;

namespace HumPsi.Infrastructure.Factory;

public interface ISqlConnFactory
{
    NpgsqlConnection GetConnection();
}