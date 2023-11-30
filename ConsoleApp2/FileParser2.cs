namespace ConsoleApp2;

public class FileParser2 : IFileParser
{
    public string[] ReadFile(string filename)
    {
        return File.ReadAllLines(filename);
    }

    public List<FileRowData> ParseData(string[] fileContent)
    {
        var result =  fileContent
           .Select(row => new FileRowData
           {
               MobileNumber = row.Split("|")[0],
               Number = Convert.ToInt32(row.Split("|")[1]),
               ValueInMillicents = Convert.ToInt64(row.Split("|")[2]),
               NumberToIgnore = Convert.ToInt32(row.Split("|")[3]),
               ResultDescription = row.Split("|")[4]
           });
        return result.ToList();
    }

    public List<DisplayDataModel> MapObjectToDisplayItems(List<FileRowData> list)
    {
        List<DisplayDataModel> result = new List<DisplayDataModel>();
        foreach (var row in list)
        {
            var item = new DisplayDataModel();
            item.MobileNumber = row.MobileNumber;
            item.ResultDescription = row.ResultDescription;
            item.Amount = (decimal)(row.ValueInMillicents ?? 0 / 1000000);
            result.Add(item);
        }
        return result;
    }

    public void DisplayRowsOfData(List<DisplayDataModel> displayItems)
    {
        foreach (var item in displayItems)
        {
            Console.WriteLine($"{item.MobileNumber} - {item.Amount:#,##0.00} - {item.ResultDescription}");
        };
    }
}

