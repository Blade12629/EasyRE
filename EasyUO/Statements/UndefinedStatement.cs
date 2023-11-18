namespace EasyRE.EasyUO.Statements
{
    public class UndefinedStatement : IStatement
    {
        public string Value { get; }

        public UndefinedStatement(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"Undefined Statement: {(Value ?? "<<NULL VALUE>>")}";
        }
    }
}
