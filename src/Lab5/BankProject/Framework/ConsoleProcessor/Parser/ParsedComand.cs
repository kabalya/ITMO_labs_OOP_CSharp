namespace BankProject;

public class ParsedComand
{
    private readonly IReadOnlyList<string> arguments;

    public ParsedComand(string name, IReadOnlyList<string> arguments)
    {
        ValueVerificator.NullStringVerificator(name);
        if (name.Length == 0) throw new ArgumentException("Null Value");

        ArgumentNullException.ThrowIfNull(arguments);

        Name = name;
        this.arguments = arguments;
    }

    public string Name { get; init; }
    public string GetArgument(int index)
    {
        if (index >= arguments.Count)
        {
            throw new ArgumentException("Its Enough!!! Its Enough of Information!!!");
        }

        return arguments[index];
    }

    public ParsedComand GetSubcommand()
    {
        var subComands = new List<string>();
        for (int i = 1; i < arguments.Count; i++)
        {
            subComands.Add(arguments[i]);
        }

        return new ParsedComand(GetArgument(0), subComands);
    }
}