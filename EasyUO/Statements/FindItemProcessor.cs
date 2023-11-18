namespace EasyRE.EasyUO
{
    public record class FindItemStatement(string? Container, string Item) : IStatement;

    public class FindItemProcessor : EUOLineProcessor
    {
        public FindItemProcessor() : base("finditem")
        {

        }

        protected override IStatement ProcessValue(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value) || valueSplit.Length < 1)
                Error("GoSub needs atleast 1 parameter");

            if (valueSplit.Length > 2)
                return new FindItemStatement(valueSplit[0], valueSplit[1]);
            else
                return new FindItemStatement(null, valueSplit[0]);
        }
    }
}
