namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Message
{
    public Message(string title, string body, int importanceLevel, bool isRead, int id)
    {
        Id = id;
        Title = title;
        Body = body;
        Importance = importanceLevel;
        IsRead = isRead;
        WrongValueValidator.NullStringError(Body);
        WrongValueValidator.NegativeValueError(Importance);
    }

    public string? Title { get; }
    public string? Body { get; }
    public int Importance { get; }
    public int Id { get; }
    public bool IsRead { get; private set; }

    public void MarkAsRead()
    {
        IsRead = true;
    }
}