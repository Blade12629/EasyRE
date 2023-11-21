namespace EasyRE.EasyUO
{
    public record class GoSubStatement(string Method) : IStatement;

    public class GoSubProcessor : EUOLineProcessor
    {
        public GoSubProcessor() : base("gosub")
        {

        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value) || valueSplit.Length < 1)
                Error("GoSub needs atleast 1 parameter");

            return new GoSubStatement(valueSplit[0]);
        }
    }
}
