namespace BankProject;

public class Transaction
{
    public Transaction(long idOfTransaction, long accountId, TypeOfTransaction type, long amountofCash)
    {
        IdOfTransaction = idOfTransaction;
        AccountId = accountId;
        Type = type;
        AmountofCash = amountofCash;
    }

    public long IdOfTransaction { get; init; }
    public long AccountId { get; init; }
    public TypeOfTransaction Type { get; init; }
    public long AmountofCash { get; init; }
}