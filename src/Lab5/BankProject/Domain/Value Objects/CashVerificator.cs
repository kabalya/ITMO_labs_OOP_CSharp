namespace BankProject;

    public class CashVerificator
    {
        public CashVerificator(long value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Value Out of range");
            }

            Value = value;
        }

        public long Value { get; init; }
    }