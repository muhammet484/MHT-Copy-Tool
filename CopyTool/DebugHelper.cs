using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyTool
{
    public static class DebugHelper
    {
        public static TextBox ConsoleStatic;
        public static void InitializeDebugHelperTools(ref TextBox Console)
        {
            ConsoleStatic = Console;
        }

        /// <summary>
        /// Console message
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string cm (object input = null)
        {
            if(input != null)
            {
                ConsoleStatic.Text = input.ToString() + " - " + ConsoleStatic.Text;
            }
            return ConsoleStatic.Text;
        }
    }
}
