using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleApp2;

internal class Program
{ 
    static void Main(string[] args)
    {
        // We have a file that needs to be parsed into class
        // object that can be displayed in the Console
        IFileParser fileParser = new FileParser2();
        // Read the File 
        // Requirements
        //   The file name to load - variable
        //   Open and read a file  -  Library, variable to store the data
        string filename = @"c:\temp\test.txt";
        string[] fileContent = fileParser.ReadFile(filename);
         
        // Parse the file content
        // Requirements

        //    method to parse
        //      - To read a single the lines 
        //      - parse the data in the line 
        //    Output list of rowdata objects

        var list = fileParser.ParseData(fileContent);
        // Map the rowData obejct to Display objects
        List<DisplayDataModel> displayItems = fileParser.MapObjectToDisplayItems(list);
        
        //var newRecord =  new DisplayData ("Mobile",12,"Descrip");
        
        // Display the rows in the Console
        fileParser.DisplayRowsOfData(displayItems);
        Console.ReadKey();
    }
}

