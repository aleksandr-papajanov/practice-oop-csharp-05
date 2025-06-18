using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.UI
{
    internal interface IMenuAction
    {
        string Key { get; }
        string Title { get; }
        void Invoke();
    }

    internal interface IMenuAction<T> : IMenuAction
    {
        T InvokeWithResult();
    }
}
