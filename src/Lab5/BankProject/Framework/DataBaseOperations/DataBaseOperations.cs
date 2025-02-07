using Npgsql;
namespace BankProject;

public class DataBaseOperations : IAccountStorage
    {
        private readonly NpgsqlDataSource dataSource;

        public DataBaseOperations(string host, string user, string password, string database)
        {
            ValueVerificator.NullStringVerificator(host);
            ValueVerificator.NullStringVerificator(user);
            ValueVerificator.NullStringVerificator(password);
            ValueVerificator.NullStringVerificator(database);
            string connectionString = "Host=" + host + ";Username=" + user + ";Password=" + password + ";Database=" + database;
            dataSource = new NpgsqlDataSourceBuilder(connectionString)
                .EnableRecordsAsTuples()
                .Build();

            CreateTables();
        }

        public Account CreateAccount(string password, string name)
        {
            ValueVerificator.NullStringVerificator(password);
            ValueVerificator.NullStringVerificator(name);
            using (NpgsqlCommand command =
                   dataSource.CreateCommand("INSERT INTO clients (password, name, balance) VALUES ($1, $2, $3) RETURNING id"))
            {
                command.Parameters.AddWithValue(password);
                command.Parameters.AddWithValue(name);
                command.Parameters.AddWithValue(0);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new Account(reader.GetInt64(0), password, name, 0);
                }
            }
        }

        public void DeleteAccount(Account account)
        {
            if (account is null) throw new ArgumentException("Wrong Argument");
            using (NpgsqlCommand command = dataSource.CreateCommand("DELETE FROM clients WHERE id = $1"))
            {
                command.Parameters.AddWithValue(account.Id);
                command.ExecuteNonQuery();
            }
        }

        public void SaveAccount(Account account)
        {
            if (account is null) throw new ArgumentException("Wrong Argument");
            using (NpgsqlCommand command = dataSource.CreateCommand("UPDATE clients SET password = $1, name = $2, balance = $3 WHERE id = $4"))
            {
                command.Parameters.AddWithValue(account.Password);
                command.Parameters.AddWithValue(account.Name);
                command.Parameters.AddWithValue(account.Balance);
                command.Parameters.AddWithValue(account.Id);
                command.ExecuteNonQuery();
            }
        }

        public Account? FindAccount(long id)
        {
            using (NpgsqlCommand command = dataSource.CreateCommand("SELECT password, name, balance FROM clients WHERE id = $1"))
            {
                command.Parameters.AddWithValue(id);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new Account(
                        id,
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetInt64(2));
                }
            }
        }

        public Transaction CreateTransaction(long id, TypeOfTransaction type, long amountOfCash)
        {
            using (NpgsqlCommand command = dataSource.CreateCommand("INSERT INTO transactions (account_id, type, money) VALUES ($1, $2, $3) RETURNING id"))
            {
                command.Parameters.AddWithValue(id);

                string? parameterName = Enum.GetName(typeof(TypeOfTransaction), type);
                ValueVerificator.NullStringVerificator(parameterName);
                if (parameterName != null) command.Parameters.AddWithValue(parameterName);
                command.Parameters.AddWithValue(amountOfCash);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new Transaction(reader.GetInt64(0), id, type, amountOfCash);
                }
            }
        }

        public IReadOnlyList<Transaction> Transactions(long id, int limit)
        {
            using (NpgsqlCommand command = dataSource.CreateCommand("SELECT id, account_id, type, money FROM transactions WHERE account_id = $1 LIMIT $2"))
            {
                command.Parameters.AddWithValue(id);
                command.Parameters.AddWithValue(limit);

                var transactions = new List<Transaction>();

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var type = (TypeOfTransaction)Enum.Parse(typeof(TypeOfTransaction), reader.GetString(2));
                        transactions.Add(new Transaction(reader.GetInt64(0), reader.GetInt64(1), type, reader.GetInt64(3)));
                    }
                }

                return transactions.AsReadOnly();
            }
        }

        private void CreateTables()
        {
            using (NpgsqlCommand command = dataSource.CreateCommand("CREATE TABLE IF NOT EXISTS clients (id BIGSERIAL PRIMARY KEY, password VARCHAR(256), name VARCHAR(256), balance BIGINT)"))
            {
                command.ExecuteNonQuery();
            }

            using (NpgsqlCommand command = dataSource.CreateCommand("CREATE TABLE IF NOT EXISTS transactions (id BIGSERIAL PRIMARY KEY, account_id BIGINT, type VARCHAR(64), money BIGINT)"))
            {
                command.ExecuteNonQuery();
            }
        }
    }