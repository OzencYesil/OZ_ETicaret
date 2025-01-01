using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace OZ_ETicaret.API.CustomColumnWriters
{
    public class UserNameColumnWriter : ColumnWriterBase
    {
        public UserNameColumnWriter(NpgsqlDbType dbType, int? columnLength = null) : base(NpgsqlDbType.Varchar, columnLength)
        {
        }

        public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
        {
           KeyValuePair<string, LogEventPropertyValue> result = logEvent.Properties.FirstOrDefault(p => p.Key == "username");
            return result.Value?.ToString() ?? null;
        }
    }
}
