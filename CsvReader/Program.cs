using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

using var reader = new StreamReader("csv_example.csv");
using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

var records = csv.GetRecordsAsync<FooRecord>();

await foreach (var record in records)
{
    Console.WriteLine("{0}_{1}", record.OriginCode, record.SourceStation);
}

public record FooRecord
{
    [Name("origin_code")]
    public string? OriginCode { get; init; }

    [Name("station_1")]
    public string? SourceStation { get; init; }
}