using System;
using System.Collections.Generic;
using BankProject;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class MockAccountStorage : IAccountStorage
{
    private readonly IDictionary<long, Account> clients = new Dictionary<long, Account>();
    private readonly IDictionary<long, Transaction> transactions = new Dictionary<long, Transaction>();
    private long clientId;
    private long transactionId;

    public Account CreateAccount(string password, string name)
    {
        clientId++;
        var client = new Account(clientId, password, name, 0);
        clients[clientId] = client;
        return client;
    }

    public Account? FindAccount(long id)
    {
        if (clients.TryGetValue(id, out Account? client))
        {
            return new Account(client.Id, client.Password, client.Name, client.Balance);
        }

        return null;
    }

    public void SaveAccount(Account account)
    {
        ArgumentNullException.ThrowIfNull(account);

        clients[account.Id] = new Account(account.Id, account.Password, account.Name, account.Balance);
    }

    public void DeleteAccount(Account account)
    {
        ArgumentNullException.ThrowIfNull(account);

        clients.Remove(account.Id);
    }

    public Transaction CreateTransaction(long id, TypeOfTransaction type, long amountOfCash)
    {
        transactionId++;
        var transaction = new Transaction(transactionId, id, type, amountOfCash);
        transactions[transactionId] = transaction;
        return transaction;
    }

    public IReadOnlyList<Transaction> Transactions(long id, int limit)
    {
        var outTransactions = new List<Transaction>();

        foreach (Transaction transaction in transactions.Values)
        {
            if (transaction.AccountId == id)
            {
                outTransactions.Add(transaction);
            }
        }

        return outTransactions.AsReadOnly();
    }
}