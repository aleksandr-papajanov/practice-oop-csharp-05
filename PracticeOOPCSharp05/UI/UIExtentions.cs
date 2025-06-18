using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.UI
{
    internal static class UIExtentions
    {
        public static void Print(this IEnumerable<IMenuAction> action, IUI ui)
        {
            foreach (var current in action)
            {
                ui.Write($"{current.Key}. {current.Title}", UIMessageType.Menu);
            }
        }

        public static string GetEnumOptions<T>() where T : Enum
        {
            return string.Join(", ", Enum.GetNames(typeof(T)));
        }
    }
}
