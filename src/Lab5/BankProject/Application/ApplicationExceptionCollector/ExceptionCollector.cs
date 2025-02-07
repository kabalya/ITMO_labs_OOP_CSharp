namespace BankProject;

public class ExceptionCollector : IExceptionCollector
{
    private List<string> ListOfErrors { get; set; } = new List<string>();
    public void AddExceptionToList(string stringValue)
    {
        ListOfErrors?.Add(stringValue);
    }
}