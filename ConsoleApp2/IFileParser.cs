namespace ConsoleApp2;

public interface IFileParser
{
    void DisplayRowsOfData(List<DisplayDataModel> displayItems);
    List<DisplayDataModel> MapObjectToDisplayItems(List<FileRowData> list);
    List<FileRowData> ParseData(string[] fileContent);
    string[] ReadFile(string filename);
     
}