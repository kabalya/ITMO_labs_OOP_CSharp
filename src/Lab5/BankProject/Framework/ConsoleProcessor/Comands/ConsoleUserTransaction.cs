namespace BankProject;

public class ConsoleUserTransaction : ITransactionInfoPrinter
{
    public void Print(Transaction transaction)
    {
        if (transaction is null) throw new ArgumentException(" Wrong argument");
        string? typeName = Enum.GetName(typeof(TypeOfTransaction), transaction.Type);
        ValueVerificator.NullStringVerificator(typeName);

        System.Console.WriteLine("Id: " + transaction.IdOfTransaction + " Type Of transaction: " + typeName + " Amount of cash in balance: " + transaction.AmountofCash);
    }
}