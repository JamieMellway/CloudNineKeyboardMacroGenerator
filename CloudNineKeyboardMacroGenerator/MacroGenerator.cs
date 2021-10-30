using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNineKeyboardMacroGenerator
{
    internal class MacroGenerator
    {

        const int fixedDelayInMilliseconds = 1;
        const string lineFeed = "\n";
        const int shiftKey = 161;
        string script;
        int stepNum;
        string steps;
        string fileOutput;
        public MacroGenerator(string filename, string script)
        {
            this.script = script;
            this.stepNum = -1;
            this.steps = "";

            fileOutput = "";
            fileOutput += "[General]" + lineFeed;
            fileOutput += "Version=0" + lineFeed;
            fileOutput += "[Macro]" + lineFeed;
            fileOutput += "Name=" + filename + lineFeed;
        }

        public string CreateMacro()
        {
            int shiftKey = 161;

            foreach (char c in script)
            {
                var key = new Key(c);

                if (c == '\n')
                {
                    int keyPressed = 13;
                    steps += "MacroStep" + ++stepNum + "=0," + keyPressed + ",0" + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=3, " + fixedDelayInMilliseconds + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=0," + keyPressed + ",1" + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=3, " + fixedDelayInMilliseconds + lineFeed;
                }
                else if (key.WithShift)
                {
                    steps += "MacroStep" + ++stepNum + "=0," + shiftKey + ",0" + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=3, " + fixedDelayInMilliseconds + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=0," + key.KeyPressed + ",0" + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=3, " + fixedDelayInMilliseconds + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=0," + key.KeyPressed + ",1" + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=3, " + fixedDelayInMilliseconds + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=0," + shiftKey + ",1" + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=3, " + fixedDelayInMilliseconds + lineFeed;
                }
                else
                {
                    steps += "MacroStep" + ++stepNum + "=0," + key.KeyPressed + ",0" + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=3, " + fixedDelayInMilliseconds + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=0," + key.KeyPressed + ",1" + lineFeed;
                    steps += "MacroStep" + ++stepNum + "=3, " + fixedDelayInMilliseconds + lineFeed;
                }
            }
            fileOutput += "MacroStepNum=" + (++stepNum) + lineFeed;
            fileOutput += steps;

            return fileOutput;
        }
    }
}
