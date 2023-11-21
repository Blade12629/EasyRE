namespace EasyRE.EasyUO
{
    public abstract class EUOLineProcessor
    {
        public string Key { get; }

        public EUOLineProcessor(string key)
        {
            Key = key;
        }

        public IStatement ProcessLine(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return ProcessLine(value, 
                                    Array.Empty<string>());

            string[] valueSplit = value.Split(' ');
            return ProcessLine(value, 
                                valueSplit);
        }

        protected abstract IStatement ProcessLine(string? value, string[] valueSplit);

        protected virtual void Error(string error)
        {
            throw new Exception(error);
        }
    }
}
