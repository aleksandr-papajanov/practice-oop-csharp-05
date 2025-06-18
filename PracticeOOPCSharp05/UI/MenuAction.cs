using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.UI
{
    internal class MenuAction : IMenuAction
    {
        private readonly Action _action;

        public string Key { get; }
        public string Title { get; }
        public MenuAction(string key, string title, Action action)
        {
            _action = action;

            Key = key;
            Title = title;
        }

        public void Invoke() => _action();
    }

    internal class MenuAction<T> : IMenuAction<T>
    {
        private readonly Func<T> _action;

        public string Key { get; }
        public string Title { get; }

        public MenuAction(string key, string title, Func<T> action)
        {
            _action = action;

            Key = key;
            Title = title;
        }

        public void Invoke() => _action();
        public T InvokeWithResult() => _action();
    }
}
