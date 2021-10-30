using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CloudNineKeyboardMacroGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: CloudNineKeyboardMacroGenerator.exe filename_without_extension script_in_quotes");
                Console.WriteLine("Example: CloudNineKeyboardMacroGenerator.exe SUDO \"sudo su - `./ GetServiceId.sh`\\ntcsh\\nset prompt = '%/% '\\nbindkey - k up history - search - backward\\nbindkey - k down history - search - forward\\n\"");
            }
            else
            {
                string filename = args[0];
                string script = args[1];
                string unescapedScript = System.Text.RegularExpressions.Regex.Unescape(script);
                var generateMacro = new MacroGenerator(filename, unescapedScript);
                var fileOutput = generateMacro.CreateMacro();

                File.WriteAllText(filename + ".mac", fileOutput);
            }
        }

    }
}
