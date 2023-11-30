namespace ConsoleApp2;

public class DisplayDataModel
{
    public DisplayDataModel () { }
    public DisplayDataModel(string mobileNumber, decimal amount, string resultDescription)
    {
        MobileNumber = mobileNumber;
        Amount = amount;
        ResultDescription = resultDescription;
    }

    public string MobileNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string ResultDescription { get; set; } = string.Empty;


    
}

