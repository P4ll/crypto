using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace crypto_test {
    class SquareConGen : Generator {
        private RichTextBox _textBox;
        
        private const long SEED = 19;
        private const long A_CONST = 1103515245;
        private const long B_CONST = 48271;//65539;
        private const long C_CONST = 0; //12345;
        private const long M_CONST = (long)1 << 31;
        private long curAns = SEED;

        public SquareConGen(ref RichTextBox textBox) : base(ref textBox) {
            Gen = generateSeq;
            _textBox = textBox;
        }

        public long Next() {
            //curAns = ((A_CONST * A_CONST * curAns) % M_CONST + B_CONST * curAns + C_CONST) % M_CONST;
            //curAns = add(mult(B_CONST, curAns), C_CONST);
            curAns = add(add(mult(mult(A_CONST, A_CONST), curAns), mult(B_CONST, curAns)), C_CONST);
            Console.WriteLine(curAns);
            return curAns;
        }

        private string generateSeq(int numbers, ref Utils.Progress progressForm) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers; ++i) {
                Next();
                sb.Append(curAns & 1);
                progressForm.PerformStep();
            }
            progressForm.CloseFormSafe();
            string strAns = sb.ToString();
            Utils.MultiThreadHelper.SetTextBoxSafe(strAns, ref _textBox);
            return strAns;
        }

        private long mult(long num1, long num2) {
            return (num1 * num2) % M_CONST;
        }

        private long add(long num1, long num2) { 
            return (num1 + num2) % M_CONST;
        }
    }
}
