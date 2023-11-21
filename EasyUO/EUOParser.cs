using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRE.EasyUO
{
    public class EUOParser
    {
        public IReadOnlyList<IStatement> Statements => _statements;

        readonly List<IStatement> _statements;
        readonly Dictionary<string, EUOLineProcessor> _processors;

        public EUOParser(string script) : this()
        {
            _statements = new List<IStatement>();
            Parse(script);
        }

        EUOParser()
        {
            _statements = new List<IStatement>();
            _processors = new Dictionary<string, EUOLineProcessor>();

            RegisterProcessors();
        }

        public static EUOParser FromFile(string path)
        {
            return new EUOParser(File.ReadAllText(path));
        }

        void RegisterProcessors()
        {
            foreach (Type type in typeof(EUOLineProcessor).Assembly.GetTypes())
            {
                if (!type.IsSubclassOf(typeof(EUOLineProcessor)))
                    continue;

                EUOLineProcessor? processor = Activator.CreateInstance(type) as EUOLineProcessor;

                if (processor is null)
                    continue;

                RegisterProcessor(processor);
            }
        }

        void RegisterProcessor(EUOLineProcessor processor)
        {
            _processors.Add(processor.Key, processor);
        }

        void Parse(string script)
        {
            int position = 0;

            while (position < script.Length)
            {
                string line = MoveNext(script, ref position);
                IStatement? statement = ParseStatement(line);

                if (statement is null)
                    continue;

                _statements.Add(statement);
            }
        }

        IStatement? ParseStatement(string line)
        {
            line = StripComments(line);
            line = line.Trim().Trim('\t');

            if (string.IsNullOrEmpty(line))
                return null;

            // handle methods
            if (line[0] == '_')
                line = line.Insert(1, " ");

            IStatement? statement = null;
            int spaceIndex = line.IndexOf(' ');
            if (spaceIndex < 0)
            {
                statement = TryApplyProcessor(line, null);
            }
            else
            {
                string key = line.Substring(0, spaceIndex);
                string value = line.Remove(0, spaceIndex + 1);

                statement = TryApplyProcessor(key, value);
            }

            if (statement is not null)
                return statement;

            return new UndefinedStatement(line);
        }

        IStatement? TryApplyProcessor(string key, string? value)
        {
            if (!_processors.TryGetValue(key.ToLower(), out EUOLineProcessor? processor))
                return null;

            return processor.ProcessLine(value);
        }

        string StripComments(string line)
        {
            int commentIndex = line.IndexOf(';');

            if (commentIndex < 0)
                return line;

            return line.Substring(0, commentIndex);
        }

        string MoveNext(string script, ref int position)
        {
            int start = position;
            int newLineIndex = script.IndexOf(Environment.NewLine, position, script.Length - position);

            if (newLineIndex < 0)
            {
                position = script.Length;
                return script.Remove(0, start);
            }

            position = newLineIndex + 1;
            return script.Substring(start + 1, newLineIndex - start - 1);
        }
    }
}
