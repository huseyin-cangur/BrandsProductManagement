

using Core.CrossCuttingConcerns.Serilog.ConfigurationsModel;
using Core.CrossCuttingConcerns.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Serilog.Logger
{
    public class MsSqlLogger : LoggerServiceBase
    {
        public MsSqlLogger(IConfiguration configuration)
        {
            MsSqlConfiguration msSqlConfiguration =
            configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
            ?? throw new Exception(SerilogMessage.NullOptionsMessage);

            MSSqlServerSinkOptions sinkOptions = new()
            {
                TableName = msSqlConfiguration.TableName,
                AutoCreateSqlDatabase = msSqlConfiguration.AutoCreateSqlTable,
            };

            ColumnOptions columnOptions = new();

            global::Serilog.Core.Logger seriLogConfig = new LoggerConfiguration().WriteTo.MSSqlServer(msSqlConfiguration.ConnectionString, sinkOptions, columnOptions: columnOptions)
            .CreateLogger();

            Logger = seriLogConfig;
        }
    }
}