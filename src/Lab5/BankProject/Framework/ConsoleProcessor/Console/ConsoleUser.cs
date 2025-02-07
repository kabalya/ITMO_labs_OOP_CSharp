using System.Globalization;

namespace BankProject;

public class ConsoleUser : IUser
    {
        private readonly IAccountStorage _accountStorage;
        private readonly string administratorPassword;

        public ConsoleUser(IAccountStorage accountStorage, string administratorPassword)
        {
            this._accountStorage = accountStorage;
            this.administratorPassword = administratorPassword;
        }

        public static ComandParser CreateUserParser(Account account)
        {
            if (account is null) throw new ArgumentException("Wrong Argument");
            return new ComandParser()
                 .AddInitializer("deposit", new Deposit(account.Id))
                 .AddInitializer("withdraw", new WithdrawUserComand(account.Id))
                 .AddInitializer("balance", new InfoShow(account.Id, new ConsoleAccountBalance()))
                 .AddInitializer("transactions", new TransactionUserComand(account.Id, new ConsoleUserTransaction()));
        }

        public static ComandParser CreateAdminParser()
        {
            return new ComandParser()
                .AddInitializer("createclient", new AccountCreate(new ConsoleInfoCreateAccount()))
                .AddInitializer("deposit", new AdministratorDeposit())
                .AddInitializer("balance", new AdministratorInformation(new ConsoleAdminBalance()))
                .AddInitializer("withdraw", new AdministratorCashWithdraw())
                .AddInitializer("transactions", new AdministratorDoTransaction(new ConsoleUserTransaction()));
        }

        public void OpenSession()
        {
            ISession session;
            ComandParser commandParser;

            System.Console.WriteLine("Who are You? (Admin of User ");
            string? personIdentificator = System.Console.ReadLine();
            ValueVerificator.NullStringVerificator(personIdentificator);

            if (personIdentificator != null && personIdentificator.Equals("Admin", StringComparison.Ordinal))
            {
                System.Console.WriteLine("Enter administrator password: ");
                string? enteredAdminPassword = System.Console.ReadLine();
                ValueVerificator.NullStringVerificator(enteredAdminPassword);

                if (enteredAdminPassword != null && enteredAdminPassword.Equals(administratorPassword, StringComparison.Ordinal))
                {
                    commandParser = CreateAdminParser();
                    session = new AdminAvailability();
                }
                else
                {
                    System.Console.WriteLine("Wrong Password");
                    return;
                }
            }
            else if (personIdentificator != null && personIdentificator.Equals("User", StringComparison.Ordinal))
            {
                System.Console.WriteLine("Please,enter id: ");
                string? inputedId = System.Console.ReadLine();
                ValueVerificator.NullStringVerificator(inputedId);

                long id = Convert.ToInt64(inputedId, CultureInfo.InvariantCulture);
                System.Console.WriteLine("Please,enter password: ");

                string? inputedpassword = System.Console.ReadLine();
                ValueVerificator.NullStringVerificator(inputedpassword);

                Account? account = _accountStorage.FindAccount(id);
                if (account != null && account.Password.Equals(inputedpassword, StringComparison.Ordinal))
                {
                    commandParser = CreateUserParser(account);
                    session = new AccountAvailability(account);
                }
                else
                {
                    System.Console.WriteLine("Sorry,Something went wrong");
                    return;
                }
            }
            else
            {
                System.Console.WriteLine("Wrong Input");
                return;
            }

            while (true)
            {
                string? line = System.Console.ReadLine();
                ValueVerificator.NullStringVerificator(line);

                line = line?.Trim();
                if (ValueVerificator.LengthVerificator(line?.Length)) continue;

                try
                {
                    if (line != null)
                    {
                        IUserComand comand = commandParser.Parse(line);
                        comand.Execute(session, _accountStorage);
                    }
                }
                catch (ArgumentException exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }
        }
    }