using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace crypto_test {
    class GeneratorYarrow : Generator {
        public GeneratorYarrow(ref RichTextBox textBox) : base(ref textBox) {
            Gen = generateSeq;
        }

        private string generateSeq(int numbers, ref Utils.TextProgressBar progress) {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }
    }
}
