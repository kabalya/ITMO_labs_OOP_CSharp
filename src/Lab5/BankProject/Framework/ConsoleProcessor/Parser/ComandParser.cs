namespace BankProject;

public class ComandParser
    {
        private readonly IDictionary<string, IUserComands> userComands;
        public ComandParser()
        {
            userComands = new Dictionary<string, IUserComands>();
        }

        public IUserComand Parse(string input)
        {
            ArgumentNullException.ThrowIfNull(input);

            string[] split = input.Trim().Split(" ");
            if (split.Length == 0) throw new ArgumentException("Sorry, but you didn't enter anything.");

            string name = split[0];
            if (!userComands.ContainsKey(name)) throw new ArgumentException("Sorry, You Inputed Wrong Comand");

            var arguments = new List<string>();
            for (int i = 1; i < split.Length; i++)
            {
                while (i < split.Length && split[i].Length == 0)
                {
                    i++;
                }

                if (i == split.Length)
                {
                    break;
                }

                string argument = split[i];
                arguments.Add(argument);
            }

            var parsedCommand = new ParsedComand(name, arguments.AsReadOnly());
            try
            {
                return new UserComandErrorsCatcher(userComands[name].Create(parsedCommand));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public ComandParser AddInitializer(string name, IUserComands initializer)
        {
            ValueVerificator.NullStringVerificator(name);
            if (initializer is null) throw new ArgumentException("Initializer cant be null");
            userComands[name] = initializer;
            return this;
        }
    }