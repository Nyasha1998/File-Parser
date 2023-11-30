namespace ConsoleApp2;

public class FileParser : IFileParser
{
    public string[] ReadFile(string filename)
    {
        return File.ReadAllLines(filename);
    }

    public List<FileRowData> ParseData(string[] fileContent)
    {
        List<FileRowData> result = new List<FileRowData>();
        foreach (var row in fileContent)
        {
            var item = new FileRowData();
            item.MobileNumber = row.Split("|")[0];
            item.Number = Convert.ToInt32(row.Split("|")[1]);
            item.ValueInMillicents = Convert.ToInt64(row.Split("|")[2]);
            item.NumberToIgnore = Convert.ToInt32(row.Split("|")[3]);
            item.ResultDescription = row.Split("|")[4];
            result.Add(item);
        }
        return result;
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

 
