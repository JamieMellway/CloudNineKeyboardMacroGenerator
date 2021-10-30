using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNineKeyboardMacroGenerator
{
    internal class Key
    {
        public bool WithShift { get; set; }
        public bool WithControl { get; set; }
        public bool WithAlt { get; set; }

        public int KeyPressed { get; set; }

        public Key(char ch)
        {
            short vkey = VkKeyScan(ch);
            Keys retval = (Keys)(vkey & 0xff);
            int modifiers = vkey >> 8;

            if ((modifiers & 1) != 0)
            {
                this.WithShift = true;
                //retval |= Keys.Shift;
            }
            if ((modifiers & 2) != 0)
            {
                this.WithControl = true;
                //retval |= Keys.Control;
            }
            if ((modifiers & 4) != 0)
            {
                this.WithAlt = true;
                //retval |= Keys.Alt;
            }

            KeyPressed = (int)retval;
        }


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);
    }
}
