namespace EasyRE.EasyUO
{
    //public class Processor : EUOLineProcessor
    //{
    //    public Processor() : base("")
    //    {
    //    }

    //    protected override IStatement ProcessLine(string? value, string[] valueSplit)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public record class UntilStatement(string Condition) : IStatement;
    public class UntilProcessor : EUOLineProcessor
    {
        public UntilProcessor() : base("until")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new UntilStatement(value);
        }
    }

    public record class MenuStatement(string Property, string? Arg1, string? Arg2) : IStatement;
    public class MenuProcessor : EUOLineProcessor
    {
        public MenuProcessor() : base("menu")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (valueSplit.Length > 2)
                return new MenuStatement(valueSplit[0], valueSplit[1], valueSplit[2]);
            else if (valueSplit.Length > 1)
                return new MenuStatement(valueSplit[0], valueSplit[1], null);
            else
                return new MenuStatement(valueSplit[0], null, null);
        }
    }

    public record class TargetStatement(string Distance) : IStatement;
    public class TargetProcessor : EUOLineProcessor
    {
        public TargetProcessor() : base("target")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new TargetStatement(value);
        }
    }

    public record class GotoStatement(string SubName) : IStatement;
    public class GotoProcessor : EUOLineProcessor
    {
        public GotoProcessor() : base("goto")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new GotoStatement(value);
        }
    }

    public record class LinesPerCycleStatement(string LinesPerCycle) : IStatement;
    public class LinesPerCycleProcessor : EUOLineProcessor
    {
        public LinesPerCycleProcessor() : base("linespercycle")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new LinesPerCycleStatement(value);
        }
    }

    public record class ScanJournalStatement(string ScanFor) : IStatement;
    public class ScanJournalProcessor : EUOLineProcessor
    {
        public ScanJournalProcessor() : base("scanjournal")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new ScanJournalStatement(value);
        }
    }

    public record class ForStatement(string Condition) : IStatement;
    public class ForProcessor : EUOLineProcessor
    {
        public ForProcessor() : base("for")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new ForStatement(value);
        }
    }

    public record class HideItemStatement(string Item) : IStatement;
    public class HideItemProcessor : EUOLineProcessor
    {
        public HideItemProcessor() : base("hideitem")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new HideItemStatement(value);
        }
    }

    public record class StrStatement(string Value) : IStatement;
    public class StrProcessor : EUOLineProcessor
    {
        public StrProcessor() : base("str")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new StrStatement(value);
        }
    }

    public record class HaltStatement(string Condition) : IStatement;
    public class HaltProcessor : EUOLineProcessor
    {
        public HaltProcessor() : base("halt")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new HaltStatement(value);
        }
    }

    public record class SubStatement(string SubName) : IStatement;
    public class Statements : EUOLineProcessor
    {
        public Statements() : base("sub")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new SubStatement(value);
        }
    }

    public record class ClickStatement(string X, string Y, string Arg1) : IStatement;
    public class ClickProcessor : EUOLineProcessor
    {
        public ClickProcessor() : base("click")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new ClickStatement(valueSplit[0], valueSplit[1], valueSplit[2]);
        }
    }

    public record class KeyStatement(string KeyName) : IStatement;
    public class KeyProcessor : EUOLineProcessor
    {
        public KeyProcessor() : base("key")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new KeyStatement(value);
        }
    }

    public record class NamespaceStatement(string Scope, string? Name) : IStatement;
    public class NamespaceProcessor : EUOLineProcessor
    {
        public NamespaceProcessor() : base("namespace")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (valueSplit.Length > 1)
                return new NamespaceStatement(valueSplit[0], valueSplit[1]);
            else 
                return new NamespaceStatement(valueSplit[0], null);
        }
    }

    public record class ExEventStatement(string Event) : IStatement;
    public class ExEventProcessor : EUOLineProcessor
    {
        public ExEventProcessor() : base("exevent")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new ExEventStatement(value);
        }
    }

    public record class SavePixStatement(string X, string Y, string Arg1) : IStatement;
    public class SavePixProcessor : EUOLineProcessor
    {
        public SavePixProcessor() : base("savepix")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new SavePixStatement(valueSplit[0], valueSplit[1], valueSplit[2]);
        }
    }

    public record class EventStatement(string Event) : IStatement;
    public class EventProcessor : EUOLineProcessor
    {
        public EventProcessor() : base("event")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value))
                Error("Event not found");

            return new EventStatement(value);
        }
    }

    public record class ChooseSkillStatement(string SkillName) : IStatement;
    public class ChooseSkillProcessor : EUOLineProcessor
    {
        public ChooseSkillProcessor() : base("chooseskill")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value))
                Error("SkillName not found");

            return new ChooseSkillStatement(value);
        }
    }

    public record class WhileStatement(string Condition) : IStatement;
    public class WhileProcessor : EUOLineProcessor
    {
        public WhileProcessor() : base("while")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value))
                Error("Condition not found");

            return new WhileStatement(value);
        }
    }

    public record class WaitStatement(string Time) : IStatement;
    public class WaitProcessor : EUOLineProcessor
    {
        public WaitProcessor() : base("wait")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value))
                Error("Time not found");

            return new WaitStatement(value);
        }
    }

    public record class IgnoreItemStatement(string Item) : IStatement;
    public class IgnoreItemProcessor : EUOLineProcessor
    {
        public IgnoreItemProcessor() : base("ignoreitem")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value))
                Error("Item not found");

            return new IgnoreItemStatement(value);
        }
    }

    public record class RepeatStatement() : IStatement;
    public class RepeatProcessor : EUOLineProcessor
    {
        public RepeatProcessor() : base("repeat")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new RepeatStatement();
        }
    }

    public record class ScopeStartStatement() : IStatement;
    public class ScopeStartProcessor : EUOLineProcessor
    {
        public ScopeStartProcessor() : base("{")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new ScopeStartStatement();
        }
    }

    public record class ScopeEndStatement() : IStatement;
    public class ScopeEndProcessor : EUOLineProcessor
    {
        public ScopeEndProcessor() : base("}")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new ScopeEndStatement();
        }
    }

    public record class IfStatement(string Condition) : IStatement;
    public class IfProcessor : EUOLineProcessor
    {
        public IfProcessor() : base("if")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value))
                Error("If condition is empty");

            return new IfStatement(value);
        }
    }

    public record class ElseStatement() : IStatement;
    public class ElseProcessor : EUOLineProcessor
    {
        public ElseProcessor() : base("else")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new ElseStatement();
        }
    }

    public record class ReturnStatement(string? ReturnValue) : IStatement;
    public class ReturnProcessor : EUOLineProcessor
    {
        public ReturnProcessor() : base("return")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            return new ReturnStatement(value);
        }
    }

    public record class _Statement(string MethodName) : IStatement;
    public class _Processor : EUOLineProcessor
    {
        public _Processor() : base("_")
        {
        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value))
                Error("No method name found");

            return new _Statement(value);
        }
    }

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

    public record class FindItemStatement(string? Container, string Item) : IStatement;
    public class FindItemProcessor : EUOLineProcessor
    {
        public FindItemProcessor() : base("finditem")
        {

        }

        protected override IStatement ProcessLine(string? value, string[] valueSplit)
        {
            if (string.IsNullOrEmpty(value) || valueSplit.Length < 1)
                Error("GoSub needs atleast 1 parameter");

            if (valueSplit.Length > 2)
                return new FindItemStatement(valueSplit[0], valueSplit[1]);
            else
                return new FindItemStatement(null, valueSplit[0]);
        }
    }

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
