namespace EasyRE.EasyUO
{
    public record class SetStatement(string Variable, string Value) : IStatement;

    public class SetProcessor : EUOLineProcessor
    {
        public SetProcessor() : base("set")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value) || valueSplit.Length < 2)
                Error("Set needs atleast 2 parameters");

            string variable = valueSplit[0];
            string variableValue = value.Remove(0, variable.Length + 1);

            return new SetStatement(variable, variableValue);
        }
    }
}
