using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace crypto_test {
    class SquareConGen : Generator {
        public SquareConGen(ref RichTextBox textBox) : base(ref textBox) {
            Gen = generateSeq;
        }

        private string generateSeq(int numbers, ref Utils.Progress progressForm) {

            return "";
        }
    }
}
