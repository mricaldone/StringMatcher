using CsvHelper.Configuration.Attributes;

namespace StringHelperConsole
{
    public class CsvRow
    {
        [Index(0)]
        public string Localidad { get; set; } = string.Empty;
    }
}
