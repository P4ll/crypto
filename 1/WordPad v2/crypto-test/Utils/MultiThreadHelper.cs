using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace crypto_test.Utils {
    static class MultiThreadHelper {
        private delegate void SafeCallDelegate(string text, ref RichTextBox textBox);

        public static void SetTextBoxSafe(string text, ref RichTextBox textBox) {
            if (textBox.InvokeRequired) {
                var d = new SafeCallDelegate(SetTextBoxSafe);
                textBox.Invoke(d, new object[] { text, textBox });
            }
            else {
                textBox.Text = text;
            }
        }
    }
}
