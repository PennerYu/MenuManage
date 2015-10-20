using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.ServicesFramework.ConsoleCommand
{
    public abstract class ConsoleCmdBase : IConsoleCommand
    {
        public string Key { get; set; }

        public abstract string StartLine { get; }

        public abstract string RunningLine { get; }

        public abstract string CompleteLine { get; }

        public abstract object Refresh(object[] args);

        public bool IsStarting { get; set; }

        public virtual void SetKey(string Key)
        {
            this.Key = Key;
        }
    }
}
