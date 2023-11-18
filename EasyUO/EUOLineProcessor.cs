namespace EasyRE.EasyUO
{
    public abstract class EUOLineProcessor
    {
        public string Key { get; }

        public EUOLineProcessor(string key)
        {
            Key = key;
        }

        public IStatement ProcessValue(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return ProcessValue(value, 
                                    Array.Empty<string>());

            string[] valueSplit = value.Split(' ');
            return ProcessValue(value, 
                                valueSplit);
        }

        protected abstract IStatement ProcessValue(string? value, string[] valueSplit);

        protected virtual void Error(string error)
        {
            throw new Exception(error);
        }
    }
}
