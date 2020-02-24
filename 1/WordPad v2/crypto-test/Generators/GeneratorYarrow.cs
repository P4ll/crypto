using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace crypto_test {
    public class GeneratorYarrow : Generator {
        public GeneratorYarrow(ref RichTextBox textBox) : base(ref textBox) {
            GenerateSequence = generateSeq;
            Generate = Next;
        }

        private long Next() {
            return 0;
        }

        private string generateSeq(int numbers, ref Utils.Progress progressForm) {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }
    }
}
