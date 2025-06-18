using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.UI
{
    internal interface IUI
    {
        void Run();
        void Write(string message, UIMessageType messageType, bool isInline = false);
    }
}
